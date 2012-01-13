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
    public partial class Users :Common.BasePage
    {
        MainController mainctrl = new MainController();

        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            if (!IsPostBack)
            {
                Authorize();
                hPageState.Value = Common.PageState.New;
                //load_data();
                load_Roles_data();
                loadDepartment();
            }
            ltrModule_name.Text = "User Management";
        }
        private void Authorize()
        {
            lnkDelete.Visible = lnkSave.Visible = CheckPermission(Common.Permission.ModuleName_Employee, Common.Permission.Action_Edit);
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
            LitStatus.Text = "";
            txtBxSearchKey.Text = "";
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
                IQueryable<COMSdbEntity.Role> roles = mainctrl.getRoles();
                gvAccess.DataSource = roles;
                gvAccess.AutoGenerateColumns = false;
                gvAccess.DataBind();

                IQueryable<Emp_Role_ref> emp_roles = mainctrl.retrieveEmployeeRoles(employeeID);
                if(null!=emp_roles)
                    SelectRolesInGUI(emp_roles);
                //compare with employeerole
            }
        }

        private void load_Roles_data()
        {
            IQueryable<COMSdbEntity.Role> roles = mainctrl.getRoles();
            gvAccess.DataSource = roles;
            gvAccess.AutoGenerateColumns = false;
            gvAccess.DataBind();            
        }

        protected void gvUserInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Guid employeeID;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                employeeID = ((Employee)(e.Row.DataItem)).employeeId;

                ((CheckBox)e.Row.Cells[0].FindControl("chk2ID")).InputAttributes.Add("employeeID", employeeID.ToString());
                LinkButton lnkEdit = ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit"));
                lnkEdit.CommandName = "ShowDetails";
                lnkEdit.CommandArgument = employeeID.ToString();
            }
        }

        protected void gvAccess_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Guid roleID;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                roleID = ((COMSdbEntity.Role)(e.Row.DataItem)).roleId;
                ((CheckBox)e.Row.Cells[0].FindControl("chkID")).InputAttributes.Add("roleID", roleID.ToString());
                //LinkButton lnkEdit = ((LinkButton)e.Row.Cells[0].FindControl("lnkEdit"));
                //lnkEdit.CommandName = "ShowDetails";
                //lnkEdit.CommandArgument = ID.ToString();
            }
        }

        protected void gvUserInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            hPageState.Value = Common.PageState.Update;
            if (e.CommandName.Equals("ShowDetails"))
            {
                hUpdateID.Value = e.CommandArgument.ToString();
                Employee emp = mainctrl.retrieveEmployee(new Guid(e.CommandArgument.ToString()));
                if (null != emp)
                {
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
        }

        private void loadDepartment()
        {
            DepartmentList.Items.Clear();
            foreach (Department dep in mainctrl.retrieveDepartments())
            {
                ListItem item = new ListItem(dep.name, (dep.departmentId).ToString());
                DepartmentList.Items.Add(item);
            }
        }

        private bool ValidateInput()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtStaffCode.Text.Trim()) || string.IsNullOrEmpty(txtUsername.Text.Trim()) || string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                isValid = false;
            }
            return isValid;
        }

        protected void lnkSearch_Click(object sender, EventArgs e)
        {
            Employee emp=null;
            hPageState.Value = Common.PageState.Update;
            if (!txtBxSearchKey.Text.Equals(""))
            {
                emp = mainctrl.retrieveEmployee(txtBxSearchKey.Text);
                if (null != emp)
                {
                    txtName.Text = emp.given_name;
                    txtSurname.Text = emp.surname;
                    txtBarCode.Text = emp.barcode;
                    txtPosition.Text = emp.position;
                    txtStaffCode.Text = emp.staff_code;
                    txtUsername.Text = emp.username;
                    txtPassword.Text = emp.password;
                    loadDepartment();
                    load_Roles_data(emp.employeeId);
                    hUpdateID.Value = emp.employeeId.ToString();
                    LitStatus.Text = "";
                }
            }else{
                txtBxSearchKey.Text = "";
                CleanPageState();
                load_data();
            }

        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            foreach (Guid ID in GetSelectedIDs())
            {
                mainctrl.deleteEmployee(ID);
            }

            load_data();
            load_Roles_data();
            CleanPageState();
        }

        protected void lnkSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                LitStatus.Text = "";
                return;
            }

            Employee newEmployee = new Employee();
            newEmployee.employeeId = Guid.NewGuid();
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
            newEmployee.created_by = base.GetCurentUser().username;
            newEmployee.departmentId = new Guid(DepartmentList.SelectedValue);

            if (hPageState.Value.Equals(Common.PageState.New))
            {
                mainctrl.createEmployee(newEmployee);
                List<Guid> selectedRoleID = GetSelectedRolesIDs();
                mainctrl.assignNewRole(newEmployee.employeeId, selectedRoleID, base.GetCurentUser().username, DateTime.Today);
            }
            if (hPageState.Value.Equals(Common.PageState.Update))
            {
                newEmployee.employeeId = new Guid(hUpdateID.Value);
                newEmployee.updated_by = base.GetCurentUser().username;
                newEmployee.updated_date = DateTime.Today;
                mainctrl.updateEmployee(newEmployee);
                List<Guid> selectedRoleID = GetSelectedRolesIDs();
                mainctrl.updateRole(new Guid(hUpdateID.Value), selectedRoleID, base.GetCurentUser().username, DateTime.Today);
            }
            load_data();
            CleanPageState();
            load_Roles_data();
        }

        private List<Guid> GetSelectedIDs()
        {
            List<Guid> selectedIDs = new List<Guid>();
            foreach (GridViewRow gvrow in gvUserInfo.Rows)
            {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkId = (CheckBox)gvrow.Cells[0].FindControl("chk2ID");
                    if (chkId.Checked)
                    {
                        Guid ID = new Guid(chkId.InputAttributes["employeeID"].ToString());
                        selectedIDs.Add(ID);
                    }
                }
            }
            return selectedIDs;
        }

        private List<Guid> GetSelectedRolesIDs()
        {
            List<Guid> selectedIDs = new List<Guid>();
            foreach (GridViewRow grow in gvAccess.Rows)
            {
                if (grow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkId = (CheckBox)grow.Cells[0].FindControl("chkID");
                    if (chkId.Checked)
                    {
                        Guid ID = new Guid(chkId.InputAttributes["roleID"].ToString());
                        selectedIDs.Add(ID);
                    }
                }
            }
            return selectedIDs;
        }

        private void SelectRolesInGUI(IQueryable<Emp_Role_ref> roles)
        {
            
            foreach (GridViewRow grow in gvAccess.Rows)
            {
                if (grow.RowType == DataControlRowType.DataRow)
                {
                    //COMSdbEntity.Role role = (COMSdbEntity.Role)grow.DataItem;
                    CheckBox chkId = (CheckBox)grow.Cells[0].FindControl("chkID");
                    
                    foreach (Emp_Role_ref r in roles)
                    {
                        if ((r.roleId.ToString()).Equals(chkId.InputAttributes["roleID"].ToString()))
                        {
                            chkId.Checked = true;
                        }
                    }
                }
            }
        }
    }
}