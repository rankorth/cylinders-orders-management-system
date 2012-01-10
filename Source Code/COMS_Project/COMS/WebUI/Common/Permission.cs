using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI.Common
{
    public class Permission
    {
        public const string ModuleName_Employee = "Employee";
        public const string ModuleName_Role = "Role";
        public const string ModuleName_Workflow = "Workflow";
        public const string ModuleName_StepList_Report = "StepList.aspx";
        public const string ModuleName_Employee_Performance_Report = "EmployeePerformance.aspx";

        public const string Action_Edit = "Edit";
        public const string Action_Delete ="Delete";
        public const string Action_Report = "Report";
        public const string Action_Add = "Add";

        public bool CheckPermission(string Permission_Module_Name, string Permission_Action, Employee UserObj)
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
    }
}