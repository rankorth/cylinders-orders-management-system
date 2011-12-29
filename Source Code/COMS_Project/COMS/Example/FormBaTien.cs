using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using COMSdbEntity;
using BusinessLogics;

namespace Example
{
    public partial class FormBaTien : Form
    {
        private MainController mainCtrl = new MainController();

        public FormBaTien()
        {
            InitializeComponent();
        }

        private void btnCreateOrder_Clicked(object sender, EventArgs e)
        {
            //COMSEntities context = new COMSEntities();

            try
            {
                //prepare Order
                Order order = new Order();

                order.orderId = Guid.NewGuid();
                order.barcode = order.orderId.ToString();
                order.belong_to_set = false;
                order.created_by = "Ba Tien";
                order.created_date = DateTime.Now;
                order.Customer = new Customer();
                order.dead_line = DateTime.Now;
                order.old_core = false;
                order.order_code = "order-code-111";
                order.order_type = "new-order";
                order.pay_percentage = 100;
                order.price = 1000000;
                order.price_type = 0;
                order.product_name = "Sua Bot Nguyen Kem Jolly";
                order.remark = "this is a remark";
                order.status = (int)OrderConst.STATUS_NEW;
                order.updated_by = "Ba Tien";
                order.updated_date = DateTime.Now;

                //prepare order_details from order record
                Order_Detail orderdetails = new Order_Detail();
                orderdetails.order_detailId = Guid.NewGuid();
                orderdetails.angle = 45;
                orderdetails.arrangement = 1; //1-sided or 2-sided
                orderdetails.bottom = 1;
                orderdetails.color_count = 4;
                orderdetails.created_by = "Ba Tien";
                orderdetails.created_date = DateTime.Now;
                orderdetails.cylinder_area = 500;
                orderdetails.cylinder_circumference = 80;
                orderdetails.cylinder_code = "cylinder-code-111";
                orderdetails.cylinder_hole_type = 0; //standard or others
                orderdetails.cylinder_length = 100;
                orderdetails.cylinder_type = "type-1";
                orderdetails.eye_mark_color = "color";
                orderdetails.eye_mark_height = 10;
                orderdetails.eye_mark_sign = "sign";
                orderdetails.eye_mark_width = 10;
                orderdetails.height = 90;
                orderdetails.image_orientation = "0"; //0, 90, 180, 270 degrees, or others
                orderdetails.inner_diameter = 8;
                orderdetails.key_way_height = 2;
                orderdetails.key_way_width = 2;
                orderdetails.layout_no_of_repeat_circum = 3;
                orderdetails.layout_no_of_up_horizontal = 4;
                orderdetails.no_of_cylinders = 4;
                orderdetails.orderId = order.orderId;
                orderdetails.outer_diameter = 12;
                orderdetails.print_method = 0; // reverse or surface
                orderdetails.print_width = 480;
                orderdetails.printing_web_total_print_width = 4800;
                orderdetails.printing_material = "5"; //multiple options or other
                orderdetails.reg_mark = 0; //standard or others
                orderdetails.result_based_on = "0"; //graphic proof, printing sample, fingerprint or others
                orderdetails.spliting_line_color = "color";
                orderdetails.spliting_line_side = 1; //2-sided or not
                orderdetails.spliting_line_size = 100;
                orderdetails.stretch_range = 10;
                orderdetails.top_down = 1; // top/down (1/2)
                orderdetails.updated_by = "Ba Tien";
                orderdetails.updated_date = DateTime.Now;
                orderdetails.web_width = 48;

                //add above prepared detail record into Order
                order.Order_Detail.Add(orderdetails);

                mainCtrl.createSalesOrder(order);

                ////add order record into databse
                //context.Orders.AddObject(order);

                ////make changes perminent 
                //context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Data Inserted to Order and Order_Detail table ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        private void btnUpdateOrder_Clicked(object sender, EventArgs e)
        {

            try
            {
                //Search sample
                COMSEntities context = new COMSEntities();

                //select * from Order where order_code = "code-112"
                //in example Where(o=> means  o represent Order table, u can put any thing to alias Order table there.
                //select only one record ontop = SingleOrDefault(), Take(1) means select top 1 if there are multiple records 
                Order order = mainCtrl.getSalesOrder("order-code-111");
                if (order != null)
                {
                    order.remark = "the remark has been updated";
                    foreach (Order_Detail orderDetail in order.Order_Detail)
                    {
                        orderDetail.updated_by = "System";
                    }
                    mainCtrl.updateSalesOrder(order);
                    MessageBox.Show("Updated");
                }
                else
                {
                    MessageBox.Show("Nothing to update");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Caught Exception: " + ex.Message);
            }

        }

        private void btnDeleteOrder_Clicked(object sender, EventArgs e)
        {
            try
            {
                Order dbOrder = mainCtrl.getSalesOrder("order-code-111");
                mainCtrl.deleteSpecificOder(dbOrder);
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Caught Exception: " + ex.Message);
            }

            //COMSEntities context = new COMSEntities();
            ////select * from Order where order_code = "code-112"
            ////in example Where(o=> means  o represent Order table, u can put any thing to alias Order table there.
            ////select all orders
            //IQueryable<Order> orders = context.Orders.Where(o => o.order_code == "code-112");
            //List<Order> delOrders = new List<Order>();
            //List<Order_Detail> delOrderDetails = new List<Order_Detail>();

            ////loop every order from select results
            //foreach (Order o in orders)
            //{
            //    //loop every single order_detail from order_details in each order
            //    foreach (Order_Detail od in o.Order_Detail)
            //    {
            //        //can not directly delete object here, 
            //        //mark to delete order_detail record
            //        delOrderDetails.Add(od);
            //    }
            //    //can not directly delete object here, 
            //    //mark to delete order record
            //    delOrders.Add(o);
            //}//loop again

            //foreach (Order o in delOrders) { context.Orders.DeleteObject(o); }
            //foreach (Order_Detail od in delOrderDetails) { context.Order_Detail.DeleteObject(od); }

            ////save all changes to database.
            //context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);   
        }

        private void btnCreateDept_Clicked(object sender, EventArgs e)
        {
            COMSEntities dbContext = new COMSEntities();
            try
            {
                dbContext.Departments.AddObject(createDeptObj("Sales Dept"));
                dbContext.Departments.AddObject(createDeptObj("Graphic-Repro Dept"));
                dbContext.Departments.AddObject(createDeptObj("Mechanical Dept"));
                dbContext.Departments.AddObject(createDeptObj("Production Dept"));
                dbContext.Departments.AddObject(createDeptObj("Engraving-Lasering Dept"));
                dbContext.Departments.AddObject(createDeptObj("Printing Dept"));
                dbContext.Departments.AddObject(createDeptObj("Quality Control 2 Dept"));
                dbContext.Departments.AddObject(createDeptObj("Production Mgmt Dept"));

                //make changes permanent 
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Department Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private Department createDeptObj(String name) {
            Department dept = new Department();
            dept.departmentId = Guid.NewGuid();
            dept.created_by = "Ba Tien";
            dept.created_date = DateTime.Now;
            dept.isactive = true;
            dept.name = name;
            return dept;
        }

        private void btnCreateEmpl_Clicked(object sender, EventArgs e)
        {
            COMSEntities dbContext = new COMSEntities();
            try
            {
                Employee empl = new Employee();
                empl.barcode = "";
                empl.created_by = "Ba Tien";
                empl.created_date = DateTime.Now;
                Department dept = dbContext.Departments.Where(d => d.name.Equals("Sales Dept")).FirstOrDefault();
                empl.departmentId = dept.departmentId;
                empl.employeeId = Guid.NewGuid();
                empl.given_name = "Ba Tien";
                empl.isactive = true;
                empl.password = Crypto.EncryptStringAES("tranbatien", "password");
                empl.position = "Manager";
                empl.staff_code = "staff-code-111";
                empl.surname = "Tran";
                empl.username = "tranbatien";

                dbContext.Employees.AddObject(empl);

                //make changes permanent 
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Employee "+empl.username+" Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnCreateRole_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                List<Access_Right> rightList = mainCtrl.login(txtBxUsername.Text, Crypto.EncryptStringAES(txtBxPassword.Text, "password"));
                MessageBox.Show("Logged in successfully!"+rightList.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
