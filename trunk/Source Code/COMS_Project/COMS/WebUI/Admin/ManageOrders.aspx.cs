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
            gvOrders.DataSource = orderList;
            gvOrders.AutoGenerateColumns = false;
            gvOrders.DataBind();
        }
        
    }
}