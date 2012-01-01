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
    public partial class Users : System.Web.UI.Page
    {
        MainController mainctrl = new MainController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_data();
            }
            ltrModule_name.Text = "User Management";
        }

        private void retrieveEmployeeDetail(Guid employeeID)
        {
            Employee employee = mainctrl.retrieveEmployee(employeeID);
        }

        private void load_data()
        {
            IQueryable<Employee> employees = mainctrl.retrieveAllEmployees();
            gvUserInfo.DataSource = employees;
            gvUserInfo.AutoGenerateColumns = false;
            gvUserInfo.DataBind();
        }

        protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Guid employeeID;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                employeeID = ((Employee)(e.Row.DataItem)).employeeId;

                ((CheckBox)e.Row.Cells[0].FindControl("chkID")).InputAttributes.Add("employeeID", employeeID.ToString());
                LinkButton lnkEdit = ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit"));
                lnkEdit.CommandName = "ShowDetails";
                lnkEdit.CommandArgument = employeeID.ToString();
            }
        }

        protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("ShowDetails"))
            {
                Employee emp = mainctrl.retrieveEmployee(new Guid(e.CommandArgument.ToString()));
                txtName.Text = emp.given_name;
                txtSurname.Text = emp.surname;
                txtBarCode.Text = emp.barcode;
                txtPosition.Text = emp.position;
                txtStaffCode.Text = emp.staff_code;
                txtUsername.Text = emp.username;
                txtPassword.Text = emp.password;
            }
        }
    }
}