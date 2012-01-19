using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI
{
    public partial class SetLanguage : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Authorize();
                SetLanguageDropdownlist();
            }

            
        }
        private void SetLanguageDropdownlist()
        {
            Employee User = base.GetCurentUser();
            if (User != null)
            {
                if (User.language.Equals("VN"))
                {
                    ddlLanguage.SelectedIndex = 1;
                }
                else
                {
                    ddlLanguage.SelectedIndex = 0;
                }
            }
            
        }
        private void Authorize()
        {
            lnkSave.Visible = base.CheckPermission(Common.Permission.ModuleName_Role, Common.Permission.Action_Edit);
        }
        protected void lnkSave_Click(object sender, EventArgs e)
        {
            Employee User = base.GetCurentUser();
            if (User!=null)
            {
                COMSEntities context = new COMSEntities();
                Employee emp = context.Employees.Where(u => u.employeeId == User.employeeId ).SingleOrDefault();
                emp.language=ddlLanguage.SelectedValue;
                context.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                base.SetCurrentUser(emp); 
                SetLanguageDropdownlist();
                
                Common.Utility.ShowMessage("Prefered language has been set.", Page);
                
            }
        }
    }
}