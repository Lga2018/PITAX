using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PITAX
{
    public partial class Login : System.Web.UI.Page
    {
        protected BLL.users bll = new BLL.users();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string userName = userNameId.Value;
            string passWord = password.Value;

            Model.users model = bll.GetModel(userName);
            if (model != null)
            {
                if (model.password == passWord)
                {
                    Common.Utils.WriteCookie("name", model.name);
                    Common.Utils.WriteCookie("username", userName);
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('密码错误。')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('用户名不存在。')</script>");
            }

        }

        protected void btn_reset_Click(object sender, EventArgs e)
        {

        }

    }
}