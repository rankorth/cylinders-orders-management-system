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
                hPageState.Value = Common.PageState.New;
                load_data();
                loadDepartment();
            }
            ltrModule_name.Text = "User Management";
        }

        private void retrieveEmployeeDetail(Guid employeeID)
        {
            Employee employee = mainctrl.retrieveEmployee(employeeID);
        }
        
        private void CleanPageState()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtBarCode.Text = "";
            txtPosition.Text = "";
            txtStaffCode.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            hPageState.Value = Common.PageState.New;
            hUpdateID.Value = "";
            DepartmentList.Items.Clear();
            loadDepartment();
        }

        private void load_data()
        {
            IQueryable<Employee> employees = mainctrl.retrieveAllEmployees();
            gvUserInfo.DataSource = employees;
            gvUserInfo.AutoGenerateColumns = false;
            gvUserInfo.DataBind();
        }

        private void load_Roles_data(Guid employeeID)
        {
            if(null!=employeeID){
                List<Access_Right> consolidateRights = new List<Access_Right>();
                List<COMSdbEntity.Role> roles = mainctrl.retrieveEmployeeRoles(employeeID);
                foreach (COMSdbEntity.Role role in roles)
                {
                    List<Access_Right> ar = mainctrl.retrieveAccessRights(role);
                    consolidateRights.AddRange(ar);
                }
                gvAccess.DataSource = consolidateRights;
                gvAccess.AutoGenerateColumns = false;
                gvAccess.DataBind();
            }
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

        protected void gvAccess_RowDataBound(object sender, GridViewRowEventArgs e)
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
            hPageState.Value = Common.PageState.Update;
            if (e.CommandName.Equals("ShowDetails"))
            {
                hUpdateID.Value = e.CommandArgument.ToString();
                Employee emp = mainctrl.retrieveEmployee(new Guid(e.CommandArgument.ToString()));
                txtName.Text = emp.given_name;
                txtSurname.Text = emp.surname;
                txtBarCode.Text = emp.barcode;
                txtPosition.Text = emp.position;
                txtStaffCode.Text = emp.staff_code;
                txtUsername.Text = emp.username;
                txtPassword.Text = emp.password;
                loadDepartment();                
                load_Roles_data(new Guid(e.CommandArgument.ToString()));
            }
        }

        private void loadDepartment()
        {
            foreach (Department dep in mainctrl.retrieveDepartments())
            {
                ListItem item = new ListItem(dep.name, (dep.departmentId).ToString());
                DepartmentList.Items.Add(item);
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                isValid = false;
            }
            return isValid;
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            foreach (Guid ID in GetSelectedIDs())
            {
                mainctrl.deleteEmployee(ID);
            }

            load_data();
            CleanPageState();
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                return;
            }

            Employee newEmployee = new Employee();
            newEmployee.barcode = txtBarCode.Text.Trim();
            newEmployee.given_name = txtName.Text.Trim();
            newEmployee.surname = txtSurname.Text.Trim();
            newEmployee.barcode = txtBarCode.Text.Trim();
            newEmployee.position = txtPosition.Text.Trim();
            newEmployee.staff_code = txtStaffCode.Text.Trim();
            newEmployee.username = txtUsername.Text.Trim();
            newEmployee.password = txtPassword.Text.Trim();
            newEmployee.created_date = DateTime.Today;
            newEmployee.isactive = true;
            newEmployee.created_by = "Roger";
            newEmployee.departmentId = new Guid(DepartmentList.SelectedValue);

            if (hPageState.Value.Equals(Common.PageState.New))
            {
                mainctrl.createEmployee(newEmployee);
            }
            if (hPageState.Value.Equals(Common.PageState.Update))
            {
                newEmployee.employeeId = new Guid(hUpdateID.Value);
                newEmployee.updated_by = "Dave";
                newEmployee.updated_date = DateTime.Today;
                mainctrl.updateEmployee(newEmployee);
            }
            load_data();
            CleanPageState();
        }

        private List<Guid> GetSelectedIDs()
        {
            List<Guid> selectedIDs = new List<Guid>();
            foreach (GridViewRow gvrow in gvUserInfo.Rows)
            {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkId = (CheckBox)gvrow.Cells[0].FindControl("chkID");
                    if (chkId.Checked)
                    {
                        Guid ID = new Guid(chkId.InputAttributes["employeeID"].ToString());
                        selectedIDs.Add(ID);
                    }
                }
            }
            return selectedIDs;
        }
    }
}