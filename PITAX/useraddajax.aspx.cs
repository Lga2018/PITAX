using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PITAX
{
    public partial class useraddajax : System.Web.UI.Page
    {
        protected BLL.users bll = new BLL.users();
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Common.DTRequest.GetFormString("name");
            string username = Common.DTRequest.GetFormString("username");
            string departid = Common.DTRequest.GetFormString("departid");
            string password = Common.DTRequest.GetFormString("password");
            string note= Common.DTRequest.GetFormString("note");

            int flg=0;

            if (!bll.Exists(username))
            {
                Model.users model = new Model.users();
                model.name = name;
                model.departid = departid;
                model.username = username;
                model.password = password;
                model.role = 0;
                model.addtime = DateTime.Now.ToString();
                model.note = note;
                if (bll.Add(model) > 0)
                {
                    flg = 1;
                }
                
            }
            else
            {
                //用户名存在
                flg = 2;
            }
        }
    }
}