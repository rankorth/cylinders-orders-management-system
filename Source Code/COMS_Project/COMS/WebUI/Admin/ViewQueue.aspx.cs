using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogics;
using COMSdbEntity;
using System.IO;

namespace WebUI.Admin
{
    public partial class ViewQueue : Common.BasePage
    {
        MainController mainCtrl = new MainController();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            if (!IsPostBack)
            {
                IQueryable<Workflow> workflowList = mainCtrl.getAllWorkflow();
                foreach (Workflow wf in workflowList)
                {
                    ddlWorkflow.Items.Add(new ListItem(wf.name, wf.workflowId.ToString()));
                }
            }
        }

        protected void lnkViewQueue_Click(object sender, EventArgs e)
        {
            List<Order> orderList = mainCtrl.viewQueue(new Guid(ddlWorkflow.SelectedValue));
            if (orderList != null)
            {
                gvOrders.DataSource = orderList;
                gvOrders.AutoGenerateColumns = false;
                gvOrders.DataBind();
                lblMsg.Text = "Search found " + orderList.Count() + " result(s).";
                lblMsg.CssClass = "okMsg";
                hdWorkflowName.Value = ddlWorkflow.SelectedItem.Text;
            }
            else
            {
                lblMsg.Text = "Search found no result.";
                lblMsg.CssClass = "errMsg";
            }
        }

        protected void lnkExportQueue_Click(object sender, EventArgs e)
        {
            string attachment = "attachment; filename=Queue for "+hdWorkflowName.Value+".xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gvOrders.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End(); 
        }

        //for overriding the Exception "Control 'gvOrders' of type 'GridView' must be placed inside a form tag with runat=server." 
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}