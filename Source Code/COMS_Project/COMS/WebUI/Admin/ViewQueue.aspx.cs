﻿using System;
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
            LoadResources();
            if (!IsPostBack)
            {
                IQueryable<Workflow> workflowList = mainCtrl.getAllWorkflow();
                foreach (Workflow wf in workflowList)
                {
                    ddlWorkflow.Items.Add(new ListItem(wf.name, wf.workflowId.ToString()));
                }
                lnkExportQueue.Visible = false; //don't allow to export queue if a queue hasn't been retrieved
            }
        }

        protected void lnkViewQueue_Click(object sender, EventArgs e)
        {
            List<Order> orderList = mainCtrl.viewQueue(new Guid(ddlWorkflow.SelectedValue));
            if (orderList != null && orderList.Count() > 0)
            {
                gvOrders.DataSource = orderList;
                gvOrders.AutoGenerateColumns = false;
                gvOrders.DataBind();
                lblMsg.Text = "Search found " + orderList.Count() + " result(s).";
                lblMsg.CssClass = "okMsg";
                hdWorkflowName.Value = ddlWorkflow.SelectedItem.Text;
                lnkExportQueue.Visible = true; //allow to export queue if a queue has been retrieved
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

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Order order = (Order)e.Row.DataItem;
                Order_Detail detail = order.Order_Detail.SingleOrDefault();
                
                Label lblCustomer = (Label)e.Row.FindControl("lblCustomer");
                lblCustomer.Text = order.Customer.name;

                Label lblNewCyl = (Label)e.Row.FindControl("lblNewCyl");
                lblNewCyl.Text = ""+detail.new_cyl_count;

                Label lblUsedCyl = (Label)e.Row.FindControl("lblUsedCyl");
                lblUsedCyl.Text = ""+detail.used_cyl_count;

                Label lblDiameter = (Label)e.Row.FindControl("lblDiameter");
                lblDiameter.Text = detail.cyl_diameter.ToString();

                Label lblLength = (Label)e.Row.FindControl("lblLength");
                lblLength.Text = detail.cyl_length.ToString();
            }
        }
        private void LoadResources()
        {
            lnkExportQueue.Text = GetResource("Menu", "ExportQueue");
            lnkViewQueue.Text = GetResource("Menu", "ViewQueue");
            ltrWorkflow.Text = GetResource("Menu", "Workflow");

            gvOrders.Columns[0].HeaderText = GetResource("ViewQueue", "Priority");
            gvOrders.Columns[1].HeaderText = GetResource("ViewQueue", "SetCode");
            gvOrders.Columns[2].HeaderText = GetResource("ViewQueue", "ProductName");
            gvOrders.Columns[3].HeaderText = GetResource("ViewQueue", "Customer");
            gvOrders.Columns[4].HeaderText = GetResource("ViewQueue", "DeliveryDate");
            gvOrders.Columns[5].HeaderText = GetResource("ViewQueue", "NewCylinders");
            gvOrders.Columns[6].HeaderText = GetResource("ViewQueue", "UserdCylinders");
            gvOrders.Columns[7].HeaderText = GetResource("ViewQueue", "Diameter");
            gvOrders.Columns[8].HeaderText = GetResource("ViewQueue", "Length");
        }
    }
}