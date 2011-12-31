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
            COMSEntities dbContext = new COMSEntities();

            try
            {
                //prepare Order
                Order order = new Order();
                order.belong_to_set = "";
                order.created_by = "Ba Tien";
                order.created_date = DateTime.Now;
                order.customer_id = dbContext.Customers.Where(c => c.code.Equals("12")).FirstOrDefault().customerid;
                order.customer_rep = "Client Staff A";
                order.cylinder_type = "AB";
                order.delivery_date = DateTime.Now;
                order.old_core = false;
                order.old_order_code = "";
                order.order_code = "0001-B11";
                order.order_type = OrderConst.ORDERTYPE_NEW;
                order.price_type = "STD";
                order.priority = OrderConst.PRIORITY_LOW;
                order.product_name = "Sua Bot Nguyen Kem Jolly";
                order.redo_pct = 0;
                order.set_code = "JKS312101";
                order.updated_by = "Ba Tien";
                order.updated_date = DateTime.Now;

                //prepare order_details from order record
                Order_Detail orderDetail = new Order_Detail();
                orderDetail.changes = "";
                orderDetail.circum_dir_repeat = 1;
                orderDetail.color_count = 4;
                orderDetail.color_list = "KCMY";
                orderDetail.core_type = "NEW";
                orderDetail.created_by = "Ba Tien";
                orderDetail.created_date = DateTime.Now;
                orderDetail.cyl_diameter = (decimal)(980 / 3.1416);
                orderDetail.cyl_length = 1220;
                orderDetail.eyemark_color = "K";
                orderDetail.eyemark_height = 5;
                orderDetail.eyemark_location = "1"; //1-sided or 2-sided
                orderDetail.eyemark_sign = "";
                orderDetail.eyemark_width = 10;
                orderDetail.graphic_done_date = DateTime.Now;
                orderDetail.img_orientation = "0"; //0, 90, 180, 270 degrees, or others
                orderDetail.keyhole_angle = 70;
                orderDetail.keyhole_inner_dia = 80;
                orderDetail.keyhole_keyway = "12x12";
                orderDetail.keyhole_outer_dia = 90;
                orderDetail.keyhole_type = "OTHER"; //standard or others
                orderDetail.length_dir_repeat = 1;
                orderDetail.new_cyl_count = 4;
                orderDetail.order_detailId = Guid.NewGuid();
                orderDetail.orderId = order.orderId;
                orderDetail.print_material = "OPP"; //multiple options or other
                orderDetail.print_method = "SRFC";  // reverse or surface
                orderDetail.prod_height_stretch = 0;
                orderDetail.prod_print_height = 980;
                orderDetail.prod_print_width = 1120;
                orderDetail.prod_width_stretch = 0;
                orderDetail.reg_mark_type = "TrungDong"; //standard or others
                orderDetail.result_based_on = ""; //graphic proof, printing sample, fingerprint or others
                orderDetail.sent_to_mech_date = DateTime.Now;
                orderDetail.splitline_color = "K";
                orderDetail.splitline_size = 10;
                orderDetail.splitline_type = ""; //2-sided or not
                orderDetail.updated_by = "Ba Tien";
                orderDetail.updated_date = DateTime.Now;
                orderDetail.used_cyl_count = 0;
                orderDetail.web_print_width = 1120;
                orderDetail.web_total_width = 1145;

                //add above prepared detail record into Order
                order.Order_Detail.Add(orderDetail);

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
                Order order = mainCtrl.getSalesOrder("0001-B11");
                if (order != null)
                {
                    order.priority = OrderConst.PRIORITY_HIGH;
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
                Order dbOrder = mainCtrl.getSalesOrder("0001-B11");
                mainCtrl.deleteSpecificOder(dbOrder);
                MessageBox.Show("Order "+dbOrder.order_code+"Deleted");
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

        private void btnCreateCustomer_Clicked(object sender, EventArgs e)
        {
            COMSEntities dbContext = new COMSEntities();
            try
            {
                Customer cust = new Customer();
                cust.address = "635 HỒNG BÀNG Q6 P6";
                cust.code = "12";
                cust.code_tax = "0301640003";
                cust.created_by = "Ba Tien";
                cust.created_date = DateTime.Now;
                cust.customerid = Guid.NewGuid();
                cust.fax = "9692281";
                cust.fullname = "CTY TNHH SXTM NHẤT LỢI";
                cust.name = "NHẤT LỢI";
                cust.status = "ACTIVE";
                cust.telephone = "39605972-205(HẰNG)";
                cust.updated_by = cust.created_by;
                cust.updated_date = cust.created_date;

                Printer printer = new Printer();
                printer.address = "";
                printer.code = "";
                printer.created_by = cust.created_by;
                printer.created_date = cust.created_date;
                printer.customer_id = cust.customerid;
                printer.hole_stick = "70 x 15";
                printer.name = "Anh Hà (BN) Máy 3";
                printer.printer_id = Guid.NewGuid();
                printer.slot_latch = "10 x 9 (1 Đầu)";
                printer.status = "";
                printer.updated_by = printer.created_by;
                printer.updated_date = printer.updated_date;
                cust.Printers.Add(printer);

                dbContext.Customers.AddObject(cust);
                //make changes permanent 
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Customer Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnCreateWorkflow_Clicked(object sender, EventArgs e)
        {
            COMSEntities dbContext = new COMSEntities();
            try
            {
                Workflow workflow = new Workflow();
                workflow.created_by = "Ba Tien";
                workflow.created_date = DateTime.Now;
                workflow.departmentId = dbContext.Departments.Where(d => d.name.Equals("Sales Dept")).FirstOrDefault().departmentId;
                workflow.isactive = true;
                workflow.name = "Sales to Mechanical";
                workflow.nextWorkflowID = null;
                workflow.prevWorkflowID = null;
                workflow.updated_by = workflow.created_by;
                workflow.updated_date = workflow.created_date;
                workflow.workflowId = Guid.NewGuid();

                dbContext.Workflows.AddObject(workflow);
                //make changes permanent 
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Workflow Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnCreateCylinder_Clicked(object sender, EventArgs e)
        {
            COMSEntities dbContext = new COMSEntities();
            try
            {
                Order order = dbContext.Orders.Where(o => o.order_code.Equals("0001-B11")).FirstOrDefault();
                Order_Detail orderDetail = order.Order_Detail.FirstOrDefault();
                Cylinder cyl = new Cylinder();
                cyl.color_no = 1;
                cyl.core_type = CylinderConst.CORETYPE_NEW;
                cyl.created_by = order.created_by;
                cyl.created_date = order.created_date;
                cyl.cyl_no = 1;
                cyl.cylinderId = Guid.NewGuid();
                cyl.diameter = orderDetail.cyl_diameter;
                cyl.length = orderDetail.cyl_length;
                cyl.order_detailId = orderDetail.order_detailId;
                cyl.status = 1;
                cyl.stepId = null;
                cyl.updated_by = cyl.created_by;
                cyl.updated_date = cyl.created_date;
                cyl.workflowId = dbContext.Workflows.Where(w => w.name.IndexOf("Sales") > -1).FirstOrDefault().workflowId;
                cyl.barcode = order.order_code + "0" + cyl.cyl_no + "+0" + cyl.color_no + cyl.core_type;

                dbContext.Cylinders.AddObject(cyl);
                //make changes permanent 
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Cylinder Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnViewQueue_Clicked(object sender, EventArgs e)
        {
            COMSEntities dbContext = new COMSEntities();
            try
            {
                Workflow workflow = dbContext.Workflows.Where(w => w.name.IndexOf("Sales") > -1).FirstOrDefault();
                List<Order> orderList = mainCtrl.viewQueue(workflow.workflowId);
                foreach (Order order in orderList)
                {
                    MessageBox.Show("Order "+order.order_code+" are under workflow "+workflow.name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
