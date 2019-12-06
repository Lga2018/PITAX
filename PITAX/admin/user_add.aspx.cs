using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PITAX.admin
{
    public partial class user_add : System.Web.UI.Page
    {
        protected BLL.users bll = new BLL.users();
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {        
             
            string name = txt_name.Value;
            string departid = txt_departid.Value;
            string username = txt_username.Value;
            string password = L_pass.Value;
            string repassword = L_repass.Value; 

            if (!bll.Exists(username)) 
            {
                Model.users model = new Model.users();
                model.name = name; 
                 model.departid = departid;
                model.username = username;
                model.password = password;
                model.role = 0;  
                model.addtime = DateTime.Now.ToString();
                model.note = txt_note.Value;
                bll.Add(model);
            } 
            else
              { 
                //用户名存在
            }

        }
    }
}