using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI.Admin
{
    public partial class WebForm1 : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //generate order barcode image
            imgBarCode.ImageUrl = "BarCode.aspx?code=" + Request["code"];
        }
    }
}