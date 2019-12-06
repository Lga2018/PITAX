using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PITAX
{
    public partial class welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Common.Utils.GetCookie("name");
            if (!string.IsNullOrEmpty(name))
            {
                txt_name.InnerText = name;
            }
        }
    }
}