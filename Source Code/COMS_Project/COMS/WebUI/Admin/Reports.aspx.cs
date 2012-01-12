using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BusinessLogics;
using COMSdbEntity;

namespace WebUI.Admin
{
    public partial class Reports : Common.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.PageLoad(Page);
            if (!IsPostBack)
            {
                load_reports_list();
            }
        }

        private void load_reports_list()
        {
            COMSEntities context = new COMSEntities();
            IQueryable<Access_Right> reportlist = context.Access_Right.Where(ar => ar.action.Equals("Report"));

            foreach(Access_Right ar in reportlist)
            {
                if (base.CheckPermission(ar.module_name, ar.action))
                {
                    ddlReports.Items.Add(new ListItem(ar.name, "/Reports/" + ar.module_name));
                }
            }
        }

        protected void btnShowReports_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlReports.SelectedValue))
            {
                Response.Redirect(ddlReports.SelectedValue);
            }
        }
    }
}