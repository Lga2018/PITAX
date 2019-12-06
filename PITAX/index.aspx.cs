using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PITAX
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Common.Utils.GetCookie("name");
            string username = Common.Utils.GetCookie("username");
            if (string.IsNullOrEmpty(username))
            {
                Response.Redirect("login.aspx");
            }
            else
            {
                txt_username.InnerText = name;
            }
        }
    }
}