using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.Admin
{
    public partial class WorkflowErrorDescription : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltrModule_name.Text = "Workflow Error Message Management";
        }
    }
}