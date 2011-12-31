﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //prepare Order
            Order order = new Order();

            try
            {
                order.orderId = Guid.NewGuid();
                order.created_by = "tin";
                order.created_date = DateTime.Now;
                order.product_name = "example";

                //prepare order_details from order record
                Order_Detail orderdetails = new Order_Detail();

                orderdetails.order_detailId = Guid.NewGuid();
                orderdetails.created_by = "tin";
                orderdetails.created_date = DateTime.Now;
                orderdetails.color_count = 3;
                //add above prepared detail record into Order
                order.Order_Detail.Add(orderdetails);

                OrderController OrderCtrl = new OrderController();
                OrderCtrl.insert(order);
                ltrMsg.Text = Common.Utility.ShowMessage("successfully placed order");
            }
            catch(Exception ex)
            {
                ltrMsg.Text = Common.Utility.ShowMessage(ex.Message);
            }
        }
    }
}