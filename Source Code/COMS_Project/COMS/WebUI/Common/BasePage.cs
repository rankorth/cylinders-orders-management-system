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

        public bool login(string username, string password)
        {
            SecurityController SecurityCtrl = new SecurityController();
            Employee User =  SecurityCtrl.login(username, password);
            bool IsLogin = false;
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

            //replace with actual code once all done
            module.Add("Orders", "/Admin/ManageOrders.aspx");
            module.Add("Roles", "/Admin/Role.aspx");
            module.Add("Employee", "/Admin/Users.aspx");
            module.Add("Customer", "/Admin/Customers.aspx");
            module.Add("Approve Assign Roles", "/Admin/RoleAssignment_Approval.aspx");
            module.Add("Workflow Error Message", "/Admin/ErrorManagement.aspx");
            module.Add("Cylinder Que", "/Admin/CylinderQue.aspx");
            module.Add("Cylinder Info", "/Admin/CylinderInfo.aspx");
            module.Add("Reports", "/Admin/Reports.aspx");

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
        public bool CheckPermission(string Permission_Module_Name,string Permission_Action,Employee UserObj)
        {
            Permission permission = new Permission();
            return permission.CheckPermission(Permission_Module_Name, Permission_Action, UserObj);

        }
    }
}