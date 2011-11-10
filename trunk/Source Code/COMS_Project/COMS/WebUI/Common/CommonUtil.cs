using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Common
{
    public static class Utility
    {
        public static string ShowMessage(string msg)
        {
            return ("<script>alert(\""+msg+"\");</script>");
        }
    }
}