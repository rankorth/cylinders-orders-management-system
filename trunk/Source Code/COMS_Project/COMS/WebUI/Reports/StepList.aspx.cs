using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI.Reports
{
    public partial class StepList : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            if(!IsPostBack)
            {
                load_workflows();

            }
        }

        private void load_workflows()
        {
            try
            {
                WorkflowController WorkflowCtrl = new WorkflowController();
                IQueryable<Workflow> Workflows = WorkflowCtrl.GetAllWorkflow();

                ddlWorkflows.DataSource = Workflows;
                ddlWorkflows.DataTextField = "name";
                ddlWorkflows.DataValueField = "workflowId";
                ddlWorkflows.DataBind();
                ddlWorkflows.Items.Insert(0, new ListItem("None", "0"));
            }
            catch
            {
                Common.Utility.ShowMessage("There has been error in input data or System error found.", Page);
            }
            
        }

        protected void ddlWorkflows_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                rvSteps.LocalReport.DataSources.Clear();

                if (ddlWorkflows.SelectedValue != "0" || ddlWorkflows.SelectedValue == string.Empty)
                {
                    WorkflowController WorkflowCtrl = new WorkflowController();
                    IQueryable<Step> steps = WorkflowCtrl.GetSteps(new Guid(ddlWorkflows.SelectedValue));
                    Workflow workflow = WorkflowCtrl.GetWorkflow(new Guid(ddlWorkflows.SelectedValue));

                    if (steps.Count() <= 0 || workflow == null)
                    {
                        Common.Utility.ShowMessage("There is no search result to show.", Page);
                    }
                    ReportDataSource datasource = new ReportDataSource("Steps", steps);
                    ReportParameter paramWorkflowName = new ReportParameter("WorkflowName", workflow.name);
                    ReportParameter paramWorkflowUpdatedBy = new ReportParameter("WorkflowUpdatedBy", workflow.updated_by == null ? "" : workflow.updated_by);
                    ReportParameter paramWorkflowUpdatedDate = new ReportParameter("WorkflowUpdatedDate", workflow.updated_date == null ? "" : workflow.updated_date.ToString());

                    rvSteps.LocalReport.DataSources.Add(datasource);
                    rvSteps.LocalReport.SetParameters(paramWorkflowName);
                    rvSteps.LocalReport.SetParameters(paramWorkflowUpdatedBy);
                    rvSteps.LocalReport.SetParameters(paramWorkflowUpdatedDate);


                }
                rvSteps.LocalReport.Refresh();
            }
            catch
            {
                Common.Utility.ShowMessage("There has been error in input data or System error found.", Page);
            }
        }
    }
}