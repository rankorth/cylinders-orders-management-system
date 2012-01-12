using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMSdbEntity;
using BusinessLogics;
using WebUI.Common;

namespace WebUI.Admin
{
    public partial class ViewOrderLog : Common.BasePage
    {
        MainController mainCtrl = new MainController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid orderId = new Guid(Request["orderId"]);
                IQueryable<Order_Log> logList = mainCtrl.getOrderLogs(orderId);
                if (logList != null && logList.Count() > 0)
                {
                    Order_Log log = logList.First();
                    lblOrderCode.Text = log.Order.order_code;
                    lblProductName.Text = log.Order.product_name;

                    gvOrderLogs.DataSource = logList;
                    gvOrderLogs.AutoGenerateColumns = false;
                    gvOrderLogs.DataBind();
                    lblMsg.Text = "Search found " + logList.Count() + " result(s).";
                    lblMsg.CssClass = "okMsg";
                }
                else
                {
                    lblMsg.Text = "Search found no result.";
                    lblMsg.CssClass = "errMsg";
                }
            }
        }

        protected void linkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Common.PageUrls.ManageOrdersPage);
        }

        protected void gvOrderLogs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Order_Log log = (Order_Log)e.Row.DataItem;

                //display user-friendly order statuses
                Label lblOrderStatus = (Label)e.Row.FindControl("lblOrderStatus");
                lblOrderStatus.Text = OrderConst.DispStatusDict[log.order_status];
            }
        }
    }
}