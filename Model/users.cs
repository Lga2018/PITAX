using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户实体类
    /// </summary>
   public class users
    {
       public users() { }

       public int id { set; get; }
       /// <summary>
       /// 姓名
       /// </summary>
       public string name { set; get; }
       /// <summary>
       /// 部门ID
       /// </summary>
       public string departid { set; get; }
       /// <summary>
       /// 用户名
       /// </summary>
       public string username { set; get; }
       /// <summary>
       /// 密码
       /// </summary>
       public string password { set; get; }
       /// <summary>
       /// 角色
       /// </summary>
       public int role { set; get; }
       /// <summary>
       /// 添加时间
       /// </summary>
       public string addtime { set; get; }
       /// <summary>
       /// 备注说明
       /// </summary>
       public string note { set; get; }
    }
}
