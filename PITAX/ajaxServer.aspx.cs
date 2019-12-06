using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PITAX
{
    public partial class ajaxServer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Common.DTRequest.GetQueryString("id");
            if (!string.IsNullOrEmpty(id))
            {
                deleteUserID(id);
            }
        }
        /// <summary>
        /// 删除用户ID
        /// </summary>
        protected void deleteUserID(string id)
        {
            BLL.users bll = new BLL.users();
            bll.Delete(int.Parse(id));
        }
    }
}