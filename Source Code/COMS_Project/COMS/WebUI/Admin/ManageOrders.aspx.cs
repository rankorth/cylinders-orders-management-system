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
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrModule_name.Text = "Orders Management";
        }

        protected void lnkAddOrder_Click(object sender, EventArgs e)
        {
            clearCylindersData();
            Response.Redirect("DisplayOrder.aspx");
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
                lblMsg.CssClass = "OkMsg";
            }
            else
            {

            }

        }

        protected void gvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Order order = null;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               LinkButton lnkOrderCode = (LinkButton) e.Row.FindControl("lnkOrderCode");

               order =(Order) e.Row.DataItem;
               lnkOrderCode.Text = order.order_code.ToString();
               lnkOrderCode.CommandName = "OrderDetail";
               lnkOrderCode.CommandArgument = order.orderId.ToString();

               LinkButton lnkCylinders = ((LinkButton)e.Row.Cells[0].FindControl("lnkCylinders"));
               lnkCylinders.CommandName = "ShowAllCylinderDetails";
               lnkCylinders.CommandArgument = order.order_code.ToString();
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("OrderDetail"))
            {
                Response.Redirect("/Admin/DisplayOrder.aspx?orderId="+e.CommandArgument.ToString());
            }

            if (e.CommandName.Equals("ShowAllCylinderDetails"))
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
            }
        }

        protected void gvCylinders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ShowCylinderDetails"))
            {
                Response.Write("<SCRIPT language=\"javascript\">open('" + "/Admin/CylinderPrintPage.aspx?cylinderId=" + e.CommandArgument.ToString()+"&orderCode="+hOrderCode.Value+ "','_blank','top=0,left=0,status=yes,resizable=yes,scrollbars=yes');</script>");
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