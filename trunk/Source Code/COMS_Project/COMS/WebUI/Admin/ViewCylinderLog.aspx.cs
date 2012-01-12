using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogics;
using COMSdbEntity;
using WebUI.Common;

namespace WebUI.Admin
{
    public partial class ViewCylinderLog : Common.BasePage
    {
        MainController mainCtrl = new MainController();
        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            if (!IsPostBack)
            {
                Guid cylinderId = new Guid(Request["cylinderId"]);
                IQueryable<Cylinder_Log> logList = mainCtrl.getCylinderLogs(cylinderId);
                if (logList != null && logList.Count() > 0)
                {
                    Cylinder_Log log = logList.First();
                    lblColorNo.Text = ""+log.Cylinder.color_no;
                    lblCoreType.Text = log.Cylinder.core_type;
                    lblCylCode.Text = log.Cylinder.barcode;
                    lblCylNo.Text = "" + log.Cylinder.cyl_no;
                    lblDiameter.Text = "" + log.Cylinder.diameter;
                    lblLength.Text = "" + log.Cylinder.length;

                    gvCylLogs.DataSource = logList;
                    gvCylLogs.AutoGenerateColumns = false;
                    gvCylLogs.DataBind();
                    lblMsg.Text = "Search found " + logList.Count() + " result(s).";
                    lblMsg.CssClass = "okMsg";
                }
                else
                {
                    lblMsg.Text = "Search found no result.";
                    lblMsg.CssClass = "errMsg";
                }
            }
        }

        protected void linkBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Common.PageUrls.ManageOrdersPage);
        }
    }
}