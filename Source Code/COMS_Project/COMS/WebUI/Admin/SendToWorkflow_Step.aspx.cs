using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMSdbEntity;
using BusinessLogics;

namespace WebUI.Admin
{
    public partial class SendToWorkflow_Step : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            if (!IsPostBack)
            {
                Authorize();
                load_Workflow_Data();
            }
            Load_ErrorCylinders();
        }
        private void Authorize()
        {
            lnkSend.Visible = CheckPermission(Common.Permission.ModuleName_SendToWorkflow, Common.Permission.Action_Edit);
        }
        private void load_Workflow_Data()
        {
            WorkflowController WorkflowCtrl = new WorkflowController();
            
            ddlWorkflow.DataSource = WorkflowCtrl.GetAllWorkflow();
            ddlWorkflow.DataTextField = "name";
            ddlWorkflow.DataValueField = "workflowId";
            ddlWorkflow.DataBind();
            ddlWorkflow.Items.Insert(0,new ListItem("-- Select --",Guid.Empty.ToString()));
            ddlStep.Items.Clear();

        }

        private void Load_Steps_Data()
        {
            try
            {
                if (ddlWorkflow.SelectedIndex > 0)
                {
                    WorkflowController WorkflowCtrl = new WorkflowController();
                    Workflow workflow = WorkflowCtrl.GetWorkflow(new Guid(ddlWorkflow.SelectedValue.ToString()));
                    if (workflow != null)
                    {
                        ddlStep.Items.Clear();
                        ddlStep.DataSource = workflow.Steps.Where(s => s.isActive == true);
                        ddlStep.DataTextField = "name";
                        ddlStep.DataValueField = "stepId";
                        ddlStep.DataBind();
                        ddlStep.Items.Insert(0, new ListItem("-- Select --", Guid.Empty.ToString()));
                    }
                }
            }
            catch
            {
                Common.Utility.ShowMessage("Error occured while loading Steps. Please contact administrator", this.Page);
            }
        }

        protected void ddlWorkflow_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Steps_Data();
        }


        protected void gvResult_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ResultDAO data = (ResultDAO)e.Row.DataItem;

                LinkButton lnkSend = (LinkButton) e.Row.FindControl("lnkSend");
                lnkSend.CommandName = "Send";
                lnkSend.CommandArgument = data.cylinderid.ToString();
            }
        }

        protected void gvResult_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Send"))
            {
                CylinderController CylCtrl=new CylinderController();

                hidCylinderId.Value = e.CommandArgument.ToString();
                txtCylinderBarCode.Text = CylCtrl.viewCylinderInfo(new Guid(hidCylinderId.Value)).barcode;

            }

        }

        private void Load_ErrorCylinders()
        {
            UpdateCylinderController UpdateCylCtrl = new UpdateCylinderController();
            IQueryable<Cylinder_Log> ErrorLogs = UpdateCylCtrl.GetAllDamageOrRejectedCylinders(base.GetCurentUser());

            List<ResultDAO> ErrorCylinderResults = new List<ResultDAO>();

            foreach(Cylinder_Log cLog in ErrorLogs)
            {
                ResultDAO result = new ResultDAO();

                result.cylinderid = cLog.cylinderId;
                result.cylinderbarcode = cLog.Cylinder.barcode;
                result.department =cLog.Step.Workflow.Department.name;
                result.errordescription = cLog.error_desc;
                result.remark = cLog.remark;
                result.status = cLog.status;

                ErrorCylinderResults.Add(result);
            }

            gvResult.DataSource = ErrorCylinderResults;
            gvResult.DataBind();
        }

        protected void lnkSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlStep.SelectedIndex > 0)
                {
                    UpdateCylinderController UpdateCylCtrl = new UpdateCylinderController();
                    UpdateCylCtrl.SendToWorkflowOrStep(new Guid(hidCylinderId.Value), base.GetCurentUser(), new Guid(ddlStep.SelectedValue.ToString()), txtRemark.Text);
                    Common.Utility.ShowMessage("Cylinder has been sent successfully.", Page);
                }
            }
            catch
            {
                Common.Utility.ShowMessage("Sending Cylinder to destination step is not successful. Please contact system administrator",this.Page);
            }
        }

        
    }
        class ResultDAO
        {
            public Guid cylinderid { get; set; }
            public string cylinderbarcode { get; set; }
            public string department { get; set; }
            public string errordescription { get; set; }
            public string remark { get; set; }
            public string status { get; set; }
        }
    
}