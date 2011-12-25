using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogics;

namespace WebUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private MainController mainCtrl = new MainController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            int loginStatus = mainCtrl.login(txtUserName.Text, txtPassword.Text);
        }
    }
}