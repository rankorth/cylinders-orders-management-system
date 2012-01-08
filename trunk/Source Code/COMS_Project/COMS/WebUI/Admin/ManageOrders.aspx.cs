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
            Response.Redirect("DisplayOrder.aspx");
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
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
            }
        }

        protected void gvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("OrderDetail"))
            {
                Response.Redirect("/Admin/DisplayOrder.aspx?orderId="+e.CommandArgument.ToString());
            }
        }
        
    }
}