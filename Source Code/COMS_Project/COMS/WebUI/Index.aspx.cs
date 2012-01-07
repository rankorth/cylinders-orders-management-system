using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Prepare_Menu();
        }

        private void Prepare_Menu()
        {
            Common.BasePage bp = new Common.BasePage();
            Panel menupanel = (Panel)this.Master.FindControl("module_panel");
            LinkButton LogoutBtn = (LinkButton)this.Master.FindControl("lnkLogout");
            LogoutBtn.Visible = false;

            menupanel.Controls.Clear();

            bp.GenerateStartUpMenu(menupanel);
        }
        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Role.aspx");
        }


    }
}