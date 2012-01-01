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

using BusinessLogics;

namespace Example
{
    public partial class Form2 : Form
    {
        //Parameters for Error Controller testing
        private int value = 100;
        private Guid updateId;
        private String updateName="";

        //Parameters for Cylinder testing
        private String ORDER_CODE="";
        private Guid CYLINDERID1;
        private Guid CYLINDERID2;
        private Guid WORKFLOWID;

        //Parameters for emplyee testing
        private Guid EMPLOYEEID;

        //General
        private MainController main = new MainController();
        private COMSEntities dbContext = new COMSEntities();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        { }

        ////////////////////////////////////////////////
        //////////// INSERT NEW ERROR CODE /////////////
        ////////////////////////////////////////////////
        private void btnInsert_Click(object sender, EventArgs e)
        {

            try
            {
                //insert Error
                Error errorcode = new Error();
                errorcode.name = "Error"+ value;
                value++;

                //add order record into database
                main.createError(errorcode);

                //Acknowledge successful insertion process
                MessageBox.Show("Data Inserted into Error table");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while inserting \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        /////////////////////////////////////////////////
        //////////// INSERT NULL ERROR CODE /////////////
        /////////////////////////////////////////////////
        private void btnInsertNull_Click(object sender, EventArgs e)
        {
            try
            {
                //insert Error
                Error errorcode = null;

                //add order record into database
                main.createError(errorcode);

                //Acknowledge successful insertion process
                MessageBox.Show("Managed to catch the error");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting \n - Managed to catch the error. " + ex.Message);
            }
        }

        ////////////////////////////////////////////
        //////////// UPDATE ERROR CODE /////////////
        ////////////////////////////////////////////
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!updateName.Equals(""))
                main.updateError(updateId, updateName+" - Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating \n" + ex.Message + " - " + ex.InnerException.Message);
            }
            //Acknowledge successful update process
            MessageBox.Show("Data has been updated in Error table");
        }

        ////////////////////////////////////////////////////
        //////////// UPDATE NULL TO ERROR CODE /////////////
        ////////////////////////////////////////////////////
        private void btnUpdateNull_Click(object sender, EventArgs e)
        {
            try
            {
                main.updateError(updateId, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating \n - Managed to catch the error. " + ex.Message);
            }
        }

        ////////////////////////////////////////////////////
        //////////// DELETE UNKNOWN ERROR CODE /////////////
        ////////////////////////////////////////////////////
        private void btnDeleteNA_Click(object sender, EventArgs e)
        {
            try
            {
                main.deleteError(new Guid("00000000000000000000000000"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting \n- Managed to catch the error " + ex.Message);
            }
        }

        /////////////////////////////////////////////////
        //////////// DELETE ALL ERROR CODE //////////////
        /////////////////////////////////////////////////
        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 100; i <= value-1; i++)
                {
                    main.deleteError("Error" + i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting \n" + ex.Message);
            }
            value = 100;

            //Acknowledge successful delete process
            MessageBox.Show("Data has been deleted in Error table");

        }

        ////////////////////////////////////////////////////
        //////////// RETRIEVE ALL ERROR CODES //////////////
        ////////////////////////////////////////////////////
        private void retrieve_Click(object sender, EventArgs e)
        {
            try
            {
                IQueryable<Error> errors = main.retrieveAllErrors();
                String data = "";
                foreach (Error er in errors)
                {
                    data = data + er.name + "\n";
                    updateId = er.errorId;
                    updateName = er.name;
                }
                MessageBox.Show(data);
                data = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while retrieving error codes \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        /////////////////////////////////////////////////
        //////////// DELETE ONE ERROR CODE //////////////
        /////////////////////////////////////////////////
        private void retrieveOne_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorController ec = new ErrorController();
                Error error = ec.retrieveError(updateId);
                String data = "";
                if (null != error)
                {
                    data = data + error.name;
                }
                MessageBox.Show(data);
                data = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while retrieving error code "+updateId+" \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        //////////////////////////////////////////////////////
        //////////// CHANGE CYLINDER'S PRIORITY //////////////
        //////////////////////////////////////////////////////
        //private void changeCylinderPriority_Click(object sender, EventArgs e)
        //{
        //    try{
        //        CylinderController cc = new CylinderController();
        //        cc.changeCylinderPriority(CYLINDERID1, 1);
        //        cc.changeCylinderPriority(CYLINDERID2, 1);
        //        MessageBox.Show("Priority of Cylinder(s) successfully updated");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error occurred while saving \n" + ex.Message + " - " + ex.InnerException.Message);
        //    }
        //}

        //////////////////////////////////////////////////////////////
        //////////// CHANGE UNKNOWN CYLINDER'S PRIORITY //////////////
        //////////////////////////////////////////////////////////////
        //private void changeCylinderPriorityNA_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CylinderController cc = new CylinderController();
        //        cc.changeCylinderPriority(new Guid("00000000-9E02-4765-9C90-BD87931B546D"), 0);
        //        MessageBox.Show("No changes done to the Cylinder information");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Managed to catch the error \n" + ex.Message + " - " + ex.InnerException.Message);
        //    }
        //}

        //////////////////////////////////////////////////////////////////////
        //////////// RETRIEVE CYLINDER INFORMATION FOR PRINTING //////////////
        //////////////////////////////////////////////////////////////////////
        private void retrievePrint_Click(object sender, EventArgs e)
        {
            try
            {
                IQueryable<Cylinder> cylinders = main.viewCylinderInfo(); //Retrieve all cylinder info to display & print
                String data = "";
                int i = 0;
                foreach (Cylinder cy in cylinders)
                {
                    data = data + cy.cylinderId + "\n";
                    if (i == 0) { CYLINDERID1 = cy.cylinderId; }
                    else { CYLINDERID2 = cy.cylinderId; }
                    i++;
                }
                MessageBox.Show(data);
                data = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errors occurred while retrieving cylinder information \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        ////////////////////////////////////////////
        //////////// START PRODUCTION //////////////
        ////////////////////////////////////////////
        private void startProduction_Click(object sender, EventArgs e)
        {
            //Start production based on order, which will:
            //i) generate the cylinders based on order details information
            //ii) update the status of order and each of the cylinders' status to active.
            try
            {
                //Using SalesOrder information to generate Cylinders
                main.startCylinderProd(WORKFLOWID, ORDER_CODE);
                MessageBox.Show("Created cylinders and inserted into cylinder table ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating cylinders \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        ///////////////////////////////////////////
        //////////// STOP PRODUCTION //////////////
        ///////////////////////////////////////////
        private void stopProduction_Click(object sender, EventArgs e)
        {
            //Stop production based on cylinder, which will:
            //i) update the status of a particular cylinder to inactive.
            try
            {
                //Using SalesOrder information to generate Cylinders
                main.stopCylinderProd(CYLINDERID1);
                MessageBox.Show("Successfully stop the production for cylinder "+CYLINDERID1.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while stopping the production for cylinder "+CYLINDERID1+" \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        /////////////////////////////////////////////////
        //////////// VIEW EMPLOYEE DETAILS //////////////
        /////////////////////////////////////////////////
        private void viewEmployeeDetails_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = main.retrieveEmployee(EMPLOYEEID);
                if(null!=employee)
                   MessageBox.Show("Employee name: " + employee.surname +" "+ employee.given_name);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while retrieving employee information \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }





        /////////////////////////////////////////////////////////////////////////////////////////////////
        //////////// HELPER METHODS TO TEST REQUIREMENTS ////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////
        //////////// UNDO UPDATE ERROR CODE /////////////
        /////////////////////////////////////////////////
        private void btnUndoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!updateName.Equals(""))
                    main.updateError(updateId, updateName.Substring(0, 8));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating \n" + ex.Message + " - " + ex.InnerException.Message);
            }
            //Acknowledge successful update process
            MessageBox.Show("Data has been updated in Error table");

        }

        ///////////////////////////////////////////
        //////////// CREATE NEW ORDER /////////////
        ///////////////////////////////////////////
        private void createOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Guid custID = Guid.NewGuid();

                //Prerequisite - Need to have customer before creating order
                createCustomer(custID);

                //prepare Order
                Order order = new Order();

                order.belong_to_set = "";
                order.created_by = "Ba Tien";
                order.created_date = DateTime.Now;
                order.customer_id = custID;
                order.customer_rep = "Client Staff A";
                order.cylinder_type = "AB";
                order.delivery_date = DateTime.Now;
                order.old_core = false;
                order.old_order_code = "";
                order.order_code = "code-111"; ORDER_CODE = "code-111";
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

                main.createSalesOrder(order);

                MessageBox.Show("Data Inserted to Order and Order_Detail table ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        //////////////////////////////////////////
        //////////// CREATE CYLINDER /////////////
        //////////////////////////////////////////
        //private void createCylinder_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Using SalesOrder information to generate Cylinders
        //        main.create(ORDER_CODE);
        //        MessageBox.Show("Created cylinders and inserted into cylinder table ");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error while creating cylinders \n" + ex.Message + " - " + ex.InnerException.Message);
        //    }
        //}

        //////////////////////////////////////////
        //////////// CREATE CUSTOMER /////////////
        //////////////////////////////////////////
        private void createCustomer(Guid custID)
        {
            try
            {
                Customer firstCust = new Customer();
                firstCust.customerid = custID;
                firstCust.printer_id = Guid.NewGuid();
                firstCust.name = "frog";
                dbContext.Customers.AddObject(firstCust);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Data Inserted to Customer table ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        ////////////////////////////////////////////
        //////////// CREATE DEPARTMENT /////////////
        ////////////////////////////////////////////
        private void createDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                //Prerequisite - Need to have department before creating workflow
                Department newDep = new Department();
                newDep.departmentId = new Guid("11111111-1111-1111-1111-111111111111");
                newDep.name = "New Department";
                newDep.isactive = true;
                newDep.created_by = "frog";
                newDep.created_date = DateTime.Now;
                dbContext.Departments.AddObject(newDep);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Created a new department successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating department \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        //////////////////////////////////////////
        //////////// CREATE WORKFLOW /////////////
        //////////////////////////////////////////
        private void createWorkflow_Click(object sender, EventArgs e)
        {
            try
            {
                //Prerequisite - Need to have workflow before creating cylinder
                Workflow newWorkflow = new Workflow();
                newWorkflow.workflowId = new Guid("22222222-2222-2222-2222-222222222222");WORKFLOWID = newWorkflow.workflowId;
                newWorkflow.departmentId = new Guid("11111111-1111-1111-1111-111111111111"); 
                newWorkflow.created_by = "frog";
                newWorkflow.created_date = DateTime.Now;
                newWorkflow.name = "firstworkflow";
                newWorkflow.isactive = true;
                dbContext.Workflows.AddObject(newWorkflow);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Created a new workflow successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating workflow \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }

        //////////////////////////////////////////
        //////////// CREATE EMPLOYEE /////////////
        //////////////////////////////////////////
        private void createEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                //Prerequisite - Need to have workflow before creating cylinder
                Employee employee = new Employee();
                employee.employeeId = new Guid("88888888-8888-8888-8888-888888888888"); EMPLOYEEID = employee.employeeId;
                employee.departmentId = new Guid("11111111-1111-1111-1111-111111111111");
                employee.created_by = "frog";
                employee.created_date = DateTime.Now;
                employee.staff_code = "DummyEmployee";
                employee.username = "dummy";
                employee.password = "password";
                employee.surname = "Tan";
                employee.given_name = "Ah Xiao";
                employee.isactive = true;
                dbContext.Employees.AddObject(employee);
                dbContext.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Inserted a new employee successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting new employee information \n" + ex.Message + " - " + ex.InnerException.Message);
            }
        }
    }
}
