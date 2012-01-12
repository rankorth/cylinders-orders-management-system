using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COMSdbEntity;
using BusinessLogics;

namespace WebUI.Common
{
    public static class Utility
    {
        public static string UpdateCylinderState = "pagestate";
        //Tin (12-Jan-2012)
        public static void  ShowMessage(string msg, Page CurrentPage)
        {
            CurrentPage.Response.Write("<script>alert(\"" + msg + "\");</script>");
        }

    }

    public static class PageUrls
    {
        public const string ManageOrdersPage = "/Admin/ManageOrders.aspx";
        
        public static string BlankAdminPage = "/Admin/Blank.aspx";
    }
}