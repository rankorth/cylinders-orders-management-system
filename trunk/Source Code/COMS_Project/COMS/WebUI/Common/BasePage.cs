using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI.Common
{
    public class BasePage:System.Web.UI.Page
    {
        private string userobj = "userobj";
        protected void PageLoad(Page CurrentPage)
        {
            CheckAuthentication(CurrentPage);
        }
        public bool login(string username, string password)
        {
            bool IsLogin = false;
            try
            {
                SecurityController SecurityCtrl = new SecurityController();
                Employee User = SecurityCtrl.login(username, password);

                if (User != null)
                {
                    Session.Add(userobj, User);
                    IsLogin = true;
                }
                else
                {
                    Session.Clear();
                    Session.Add(userobj, null);
                }
            }
            catch
            {
                Common.Utility.ShowMessage("Error connecting to Data Storage. Please contact System Administrator.", this.Page);
            }
            return IsLogin;
        }

        public Employee GetCurentUser()
        {
            Employee User =null;

            if (Session[userobj] != null)
            {
                User = (Employee)Session[userobj];
            }

            return User;
        }
        public void Logout()
        {
            Session.Clear();
            Session.Add(userobj, null);  
        }
        public void GenerateMenu(Panel menu_panel)
        {
            //get current user's roles access

            Dictionary<string, string> module = new Dictionary<string, string>();
            LinkButton lnkButton;
            Employee User =GetCurentUser();


            if (Permission.CheckModuleAccess(Permission.ModuleName_Order, User))
                module.Add("Orders", "/Admin/ManageOrders.aspx");

            if (Permission.CheckModuleAccess(Permission.ModuleName_Role, User)) 
                module.Add("Roles", "/Admin/Role.aspx");

            if (Permission.CheckModuleAccess(Permission.ModuleName_Employee, User)) 
                module.Add("Employee", "/Admin/Users.aspx");

            if (Permission.CheckModuleAccess(Permission.ModuleName_Customer, User)) 
                module.Add("Customer", "/Admin/Customers.aspx");

            if (Permission.CheckModuleAccess(Permission.ModuleName_RoleApproval, User)) 
                module.Add("Approve Assign Roles", "/Admin/RoleAssignment_Approval.aspx");

            if (Permission.CheckModuleAccess(Permission.ModuleName_WorkflowError, User)) 
                module.Add("Workflow Error Message", "/Admin/ErrorManagement.aspx");

            if (Permission.CheckModuleAccess(Permission.ModuleName_ViewQue, User)) 
                module.Add("View Current Queue", "/Admin/ViewQueue.aspx");

            if (Permission.CheckModuleAccess(Permission.ModuleName_CylinderInfo, User)) 
                module.Add("Cylinder Info", "/Admin/CylinderInfo.aspx");

            if (Permission.CheckModuleAccess(Permission.ModuleName_Report, User)) 
                module.Add("Reports", "/Admin/Reports.aspx");

            Employee user = GetCurentUser();
            SecurityController SecurityCtrl = new SecurityController();

            foreach (string name in module.Keys)
            {
                lnkButton = new LinkButton();
                lnkButton.Text = name;
                lnkButton.CssClass = "module_menu";
                lnkButton.Attributes.Add("module_id", "module_id");// replace with actual module ID
                lnkButton.CausesValidation = false;
                // lnkButton.Click+=new EventHandler(e);

                lnkButton.PostBackUrl = Page.ResolveClientUrl(module[name]);

                menu_panel.Controls.Add(lnkButton);
            }

        }

        public void GenerateStartUpMenu(Panel menu_panel)
        {
            //get current user's roles access

            Dictionary<string, string> module = new Dictionary<string, string>();
            LinkButton lnkButton;

            //replace with actual code once all done
            module.Add("Cylinder Process", "/CylinderProcess.aspx");

            foreach (string name in module.Keys)
            {
                lnkButton = new LinkButton();
                lnkButton.Text = name;
                lnkButton.CssClass = "module_menu";
                lnkButton.Attributes.Add("module_id", "module_id");// replace with actual module ID
                // lnkButton.Click+=new EventHandler(e);

                lnkButton.PostBackUrl = Page.ResolveClientUrl(module[name]);

                menu_panel.Controls.Add(lnkButton);
            }
        }

        //Check user Authorization at page and Allowed Action level per module
        public bool CheckPermission(string Permission_Module_Name,string Permission_Action)
        {

            Employee UserObj = GetCurentUser();
            bool IsAuthorized = false;
            if (UserObj != null)
            {
                IsAuthorized =  Permission.CheckPermission(Permission_Module_Name, Permission_Action, UserObj);
            }

            return IsAuthorized;
        }
        public void RedirectToLoginPage(Page CurrentPage)
        {
            CurrentPage.Response.Redirect(CurrentPage.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/Index.aspx"));
        }
        private void CheckAuthentication(Page CurrentPage)
        {
            try
            {
                Common.BasePage bp = new Common.BasePage();
                if (bp.GetCurentUser() == null)
                {
                    if (!Request.Url.Segments[Request.Url.Segments.Count() - 1].ToUpper().Equals("INDEX.ASPX")
                        && !Request.Url.Segments[Request.Url.Segments.Count() - 1].ToUpper().Equals("CYLINDERPROCESS.ASPX"))
                    {
                        RedirectToLoginPage(CurrentPage);
                    }
                }
            }
            catch
            {
                
                Common.Utility.ShowMessage("Error connecting to Data Storage. Please contact System Administrator.", this.Page);
            
            }
        }


    }
}