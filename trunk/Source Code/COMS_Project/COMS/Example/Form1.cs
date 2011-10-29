using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Data.EntityClient;
using System.Data.Entity;

using COMSdbEntity;

namespace Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            COMSEntities context = new COMSEntities();

            try
            {
                //prepare Order
                Order order = new Order();

                order.orderId = Guid.NewGuid();
                order.order_type = "test";
                order.price = 100;
                order.order_code = "code-111";
                order.dead_line = DateTime.Now;
                order.created_by = "tin";
                order.created_date = DateTime.Now;
                order.product_name = "example";
                order.received_date = DateTime.Now;


                //prepare order_details from order record
                Order_Detail orderdetails = new Order_Detail();

                orderdetails.order_detailId = Guid.NewGuid();
                orderdetails.created_by = "tin";
                orderdetails.created_date = DateTime.Now;
                orderdetails.cylinder_code = "CYL001";
                orderdetails.cylinder_type = "TP1";
                orderdetails.quantity = 2;
                orderdetails.color_count = 3;

                //add above prepared detail record into Order
                order.Order_Detail.Add(orderdetails);

                //add order record into databse
                context.Orders.AddObject(order);

                //make changes perminent 
                context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Data Inserted to Order and Order_Detail table");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while saving \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Search sample
            COMSEntities context = new COMSEntities();

            //select * from Order where order_code = "code-112"
            //in example Where(o=> means  o represent Order table, u can put any thing to alias Order table there.
            //select only one record ontop = SingleOrDefault(), Take(1) means select top 1 if there are multiple records 
            Order order = context.Orders.Where(o => o.order_code == "code-111").Take(1).SingleOrDefault() ;
            if (order != null)
            {
                order.order_code = "code-112";
                order.updated_by = "tin-2";
                order.updated_date = DateTime.Now;
                context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Nothing to update");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            COMSEntities context = new COMSEntities();
            //select * from Order where order_code = "code-112"
            //in example Where(o=> means  o represent Order table, u can put any thing to alias Order table there.
            //select all orders
            IQueryable<Order> orders = context.Orders.Where(o => o.order_code == "code-112");
            List<Order> delOrders = new List<Order>();
            List<Order_Detail> delOrderDetails = new List<Order_Detail>();

            //loop every order from select results
            foreach (Order o in orders)
            {
                //loop every single order_detail from order_details in each order
                foreach (Order_Detail od in o.Order_Detail)
                {
                    //can not directly delete object here, 
                    //mark to delete order_detail record
                    delOrderDetails.Add(od);
                }
                //can not directly delete object here, 
                //mark to delete order record
                delOrders.Add(o);
            }//loop again

            foreach (Order o in delOrders) { context.Orders.DeleteObject(o); }
            foreach (Order_Detail od in delOrderDetails) { context.Order_Detail.DeleteObject(od); }

            //save all changes to database.
            context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);   
        }
    }
}
