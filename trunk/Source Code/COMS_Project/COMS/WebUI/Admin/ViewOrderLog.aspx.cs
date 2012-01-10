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
    public partial class ViewOrderLog : System.Web.UI.Page
    {
        MainController mainCtrl = new MainController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid orderId = new Guid(Request["orderId"]);
                IQueryable<Order_Log> logList = mainCtrl.getOrderLogs(orderId);
                if (logList != null)
                {
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
    }
}