using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                Common.BasePage bp = new Common.BasePage();
                bp.login("user", "password");
                if (module_panel.Controls.Count < 1)
                {
                    bp.GenerateMenu(module_panel);
                }
        }
        
    }
}