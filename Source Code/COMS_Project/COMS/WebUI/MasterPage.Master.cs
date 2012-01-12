using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMSdbEntity;

namespace WebUI
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                Common.BasePage bp = new Common.BasePage();
                
                
                if (module_panel.Controls.Count < 1)
                {
                    if (bp.GetCurentUser() != null)
                    {
                        bp.GenerateMenu(module_panel);
                    }
                }

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Common.BasePage bp = new Common.BasePage();
            bp.Logout();
            bp.RedirectToLoginPage(Page);
            
        }

        
        
        
    }
}