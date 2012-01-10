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
                
                CheckAuthentication();
                if (module_panel.Controls.Count < 1)
                {
                    bp.GenerateMenu(module_panel);
                }

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Common.BasePage bp = new Common.BasePage();
            bp.Logout();
            RedirectToLoginPage();
            
        }

        private void RedirectToLoginPage()
        {
            Response.Redirect(Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/Index.aspx"));
        }
        private void CheckAuthentication()
        {
            Common.BasePage bp = new Common.BasePage();
            if (bp.GetCurentUser() == null)
            {
                if (!Request.Url.Segments[Request.Url.Segments.Count() - 1].ToUpper().Equals("INDEX.ASPX"))
                {
                    RedirectToLoginPage();
                }
            }
        }
        
    }
}