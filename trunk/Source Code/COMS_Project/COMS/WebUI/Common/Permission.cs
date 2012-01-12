using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI.Common
{
    public static class Permission
    {
        public const string ModuleName_Employee = "Employee";
        public const string ModuleName_RoleApproval = "RoleApproval";
        public const string ModuleName_Role = "Role";
        public const string ModuleName_Assignment = "Role Assignment";
        public const string ModuleName_Workflow = "Workflow";
        public const string ModuleName_StepList_Report = "StepList.aspx";
        public const string ModuleName_Employee_Performance_Report = "EmployeePerformance.aspx";
        public const string ModuleName_CylinderInfo = "Cylinder Info";
        public const string ModuleName_Order = "Order";
        public const string ModuleName_ViewQue = "ViewQue";
        public const string ModuleName_Customer = "Customer";
        public const string ModuleName_Report = "Report";
        public const string ModuleName_WorkflowError = "Workflow Error";


        public const string Action_Edit = "Edit";
        private const string Action_Delete = "Delete";
        public const string Action_Report = "Report";
        private const string Action_Add = "Add";
        public const string Action_View = "View";

        public static bool CheckPermission(string Permission_Module_Name, string Permission_Action, Employee UserObj)
        {
            SecurityController SecurityCtrl = new SecurityController();

            List<Access_Right> AccessRights =  SecurityCtrl.GetEmployee_AccessRights(UserObj);

            bool isPermissionFound = false; 

            foreach (Access_Right access_right in AccessRights)
            {
                if (access_right.module_name.Trim().ToUpper().Equals(Permission_Module_Name.Trim().ToUpper()) &&
                   access_right.action.Trim().ToUpper().Equals(Permission_Action.Trim().ToUpper()))
                {
                    isPermissionFound = true;
                    break;
                }
            }
            return isPermissionFound;
        }

        public static bool CheckModuleAccess(string Permission_Module_Name, Employee UserObj)
        {
            if (CheckPermission(Permission_Module_Name, Action_Add, UserObj) ||
                CheckPermission(Permission_Module_Name, Action_Delete, UserObj) ||
                CheckPermission(Permission_Module_Name, Action_Edit, UserObj) ||
                CheckPermission(Permission_Module_Name, Action_Report, UserObj) ||
                CheckPermission(Permission_Module_Name, Action_View, UserObj))
            {
                return true;
            }

            return false;

        }
    }
}