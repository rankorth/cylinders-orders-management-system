using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogics;
using COMSdbEntity;

namespace WebUI.Admin
{
    public partial class ManageOrders : Common.BasePage
    {
        MainController mainctrl = new MainController();
        public const String REQ_MSG = "msg";
        public const String REQ_ORDERCODE = "orderCode";
        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            ltrModule_name.Text = "Orders Management";
            if (Request[REQ_MSG] != null) {
                if (DisplayOrder.MSG_UPDATE_OK.Equals(Request[REQ_MSG]))
                {
                    lblMsg.Text = DisplayOrder.MSG_UPDATE_OK_DESC;
                    lblMsg.CssClass = "okMsg";
                }
                else if (DisplayOrder.MSG_CANCEL_OK.Equals(Request[REQ_MSG]))
                {
                    lblMsg.Text = DisplayOrder.MSG_CANCEL_OK_DESC;
                    lblMsg.CssClass = "okMsg";
                }
                else if (DisplayOrder.MSG_STARTPROD_OK.Equals(Request[REQ_MSG]))
                {
                    lblMsg.Text = DisplayOrder.MSG_STARTPROD_OK_DESC + Request[REQ_ORDERCODE];
                    lblMsg.CssClass = "okMsg";
                }
                else if (DisplayOrder.MSG_STOPPROD_OK.Equals(Request[REQ_MSG]))
                {
                    lblMsg.Text = DisplayOrder.MSG_STOPPROD_OK_DESC + Request[REQ_ORDERCODE];
                    lblMsg.CssClass = "okMsg";
                }
            }

            if (!IsPostBack)
            {
                Authorize();
            }
        }
        //Tin 14-jan-2012
        private void Authorize()
        {
            lnkAddOrder.Visible = base.CheckPermission(Common.Permission.ModuleName_Order, Common.Permission.Action_Edit);
        }
        protected void lnkAddOrder_Click(object sender, EventArgs e)
        {
            clearCylindersData();
            Response.Redirect("/Admin/DisplayOrder.aspx");
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            clearCylindersData();
            IQueryable<Order> orderList = mainctrl.getSalesOrders(txtBxSearchKey.Text, ddlSearchType.Text);
            if (orderList != null)
            {
                gvOrders.DataSource = orderList;
                gvOrders.AutoGenerateColumns = false;
                gvOrders.DataBind();
                lblMsg.Text = "Search found "+orderList.Count()+" result(s).";
                lblMsg.CssClass = "okMsg";
            }
            else
            {
                lblMsg.Text = "Search found no result.";
                lblMsg.CssClass = "errMsg";
            }
        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Order order = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //set up link to view order details
                LinkButton lnkOrderCode = (LinkButton) e.Row.FindControl("lnkOrderCode");

                order =(Order) e.Row.DataItem;
                lnkOrderCode.Text = order.order_code.ToString();
                lnkOrderCode.CommandName = "OrderInfo";
                lnkOrderCode.CommandArgument = order.orderId.ToString();

                //display user-friendly order statuses
                Label lblOrderStatus = (Label)e.Row.FindControl("lblOrderStatus");
                lblOrderStatus.Text = OrderConst.DispStatusDict[order.status];

                //set up link to view order logs
                LinkButton lnkViewLog = (LinkButton)e.Row.FindControl("lnkViewLog");
                lnkViewLog.CommandName = "OrderLog";
                lnkViewLog.CommandArgument = order.orderId.ToString();

                //set up link to view cylinders under this order
                LinkButton lnkCylinders = ((LinkButton)e.Row.Cells[0].FindControl("lnkCylinders"));
                lnkCylinders.CommandName = "ShowAllCylinderDetails";
                lnkCylinders.CommandArgument = order.order_code.ToString();
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("OrderInfo"))
            {
                Response.Redirect("/Admin/DisplayOrder.aspx?orderId="+e.CommandArgument.ToString());
            }

            else if (e.CommandName.Equals("OrderLog"))
            {
                Response.Write("<SCRIPT language=\"javascript\">open('" + "/Admin/ViewOrderLog.aspx?orderId=" + e.CommandArgument.ToString() + "','_blank','top=0,left=0,status=yes,resizable=yes,scrollbars=yes');</script>");
            }

            else if (e.CommandName.Equals("ShowAllCylinderDetails"))
            {
                load_Cylinders_data(e.CommandArgument.ToString());
            }
        }
        
        protected void gvCylinders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String cylinderID = ((Cylinder)(e.Row.DataItem)).cylinderId.ToString();
                LinkButton lnkprint = ((LinkButton)e.Row.Cells[0].FindControl("lnkPrint"));
                lnkprint.CommandName = "ShowCylinderDetails";
                lnkprint.CommandArgument = cylinderID;

                LinkButton lnkCylLog = ((LinkButton)e.Row.Cells[0].FindControl("lnkCylLog"));
                lnkCylLog.CommandName = "ViewCylinderLogs";
                lnkCylLog.CommandArgument = cylinderID;
            }
        }

        protected void gvCylinders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ShowCylinderDetails"))
            {
                Response.Write("<SCRIPT language=\"javascript\">open('" + "/Admin/CylinderPrintPage.aspx?cylinderId=" + e.CommandArgument.ToString()+"&orderCode="+hOrderCode.Value+ "','_blank','top=0,left=0,status=yes,resizable=yes,scrollbars=yes');</script>");
            }
            else if (e.CommandName.Equals("ViewCylinderLogs"))
            {
                Response.Write("<SCRIPT language=\"javascript\">open('" + "/Admin/ViewCylinderLog.aspx?cylinderId=" + e.CommandArgument.ToString() + "&orderCode=" + hOrderCode.Value + "','_blank','top=0,left=0,status=yes,resizable=yes,scrollbars=yes');</script>");
            }
        }

        private void load_Cylinders_data(String order_code)
        {
            hOrderCode.Value = order_code;
            List<Cylinder> cylinders = mainctrl.getAllCylinders(order_code);
            gvCylinders.DataSource = cylinders;
            gvCylinders.AutoGenerateColumns = false;
            gvCylinders.DataBind();
        }

        private void clearCylindersData()
        {
            gvCylinders.DataSource = null;
            gvCylinders.DataBind();
        }
    }
}