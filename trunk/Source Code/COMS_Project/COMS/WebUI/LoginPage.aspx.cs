using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogics;
using COMSdbEntity;

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
            List<Access_Right> rightList = mainCtrl.login(txtUserName.Text, txtPassword.Text);
        }
    }
}