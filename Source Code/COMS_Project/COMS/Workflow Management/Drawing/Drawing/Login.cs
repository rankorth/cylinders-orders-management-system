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


namespace WorkflowManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            COMSEntities context = new COMSEntities();
            string inputUserName = txtUserName.Text.Trim();
            string inputPassword = txtPassword.Text;
            Employee User =  context.Employees.Where(emp => emp.username.Equals(inputUserName) && emp.password.Equals(inputPassword) 
                && emp.isactive==true  ).SingleOrDefault();

            if (User ==null)
            {
                MessageBox.Show("User Name or Password is wrong. Please try again.");
                return;
            }
            SecurityController SecurityCtrl = new SecurityController();
            List<Access_Right> access_rights = SecurityCtrl.GetEmployee_AccessRights(User);
            bool IsAuthorized = false;
            
            foreach(Access_Right ar in access_rights)
            {
                if (ar.module_name == "Workflow" && ar.isactive == true && (ar.action == "Add" || ar.action == "Edit" || ar.action == "Delete" || ar.action == "View"))
                {
                    IsAuthorized = true;
                }
            }

            if (!IsAuthorized)
            {
                MessageBox.Show("Sorry, You are not authorized to use Workflow Designer.");

            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void txtCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
