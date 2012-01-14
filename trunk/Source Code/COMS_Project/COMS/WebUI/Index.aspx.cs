using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI
{
    public partial class Index : Common.BasePage
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
            if (base.login(txtUserName.Text.Trim(), txtPassword.Text))
            {
                Response.Redirect(Common.PageUrls.BlankAdminPage);
            }
            else
            {
                lblMessage.Text = "Login Username (or) Password is wrong! Please try again.";
            }
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }


    }
}