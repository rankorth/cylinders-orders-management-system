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
        public static string ShowMessage(string msg)
        {
            return ("<script>alert(\"" + msg + "\");</script>");
        }

    }
}