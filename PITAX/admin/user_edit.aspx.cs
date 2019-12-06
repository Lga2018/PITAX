using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PITAX.admin
{
    public partial class user_edit : System.Web.UI.Page
    {
        protected BLL.users bll = new BLL.users();
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Common.Utils.GetCookie("username");
            if (!string.IsNullOrEmpty(username))
            {
                Model.users model = new Model.users();
                model = bll.GetModel(username);
                if (model != null)
                {
                    txt_name.Value = model.name;
                    txt_departid.Value = model.departid;
                    txt_username.InnerText = model.username;
                   // txt_username.Value = model.username;
                }
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

        }
    }
}