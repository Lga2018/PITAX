using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PITAX
{
    /// <summary>
    /// WebServiceLogin 的摘要说明
    /// 页面AJAX数据处理服务
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceLogin : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        [WebMethod]
        public void Login()
        {
            string username = Common.DTRequest.GetFormString("username");
            string password = Common.DTRequest.GetFormString("password");
            BLL.users bll = new BLL.users();
            Model.users model = bll.GetModel(username);
            string strmsg = "";
            if (model != null)
            {
                if (model.password == password)
                {
                    Common.Utils.WriteCookie("name", model.name);
                    Common.Utils.WriteCookie("username", password);
                   // strmsg = "登录成功";
                    strmsg = @"{Success:true,Msg:'登录成功'}";                   

                }
                else
                {
                   // strmsg = "密码错误";
                    strmsg = @"{Success:false,Msg:'密码错误'}";
                }
            }
            else
            {
                //strmsg = "用户名不存在";
                //strmsg = "{\"Success\":false,\"Msg\":\"用户名不存在！\"}";
                strmsg = @"{Success:false,Msg:'用户名不存在'}";
            }
           object objjson = JsonConvert.DeserializeObject(strmsg);
          // return strmsg;
           Context.Response.Write(objjson.ToString());
            Context.Response.End();
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        [WebMethod]
        public void AddUser()
        {
            string name = Common.DTRequest.GetFormString("name");
            string username = Common.DTRequest.GetFormString("username");
            string departid = Common.DTRequest.GetFormString("departid");
            string password = Common.DTRequest.GetFormString("password");
            string note = Common.DTRequest.GetFormString("note");

            BLL.users bll = new BLL.users();

            string strmsg = "";

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
                    strmsg = @"{Success:true,Msg:'添加成功'}";
                }

            }
            else
            {
                //用户名存在
                strmsg = @"{Success:false,Msg:'用户名已存在'}";
            }

            object objjson = JsonConvert.DeserializeObject(strmsg);//系列化Json数据
            Context.Response.Write(objjson.ToString());
            Context.Response.End();
        }
        /// <summary>
        /// 删除用户
        /// </summary>
        [WebMethod]
        public void DeleteUser()
        {
            string id = Common.DTRequest.GetFormString("userid");
            string strmsg = "";
            if (!string.IsNullOrEmpty(id))
            {
                BLL.users bll = new BLL.users();
                if (bll.Delete(int.Parse(id)))
                {
                    strmsg = @"{Success:true,Msg:'删除成功'}";
                }
                else
                {
                    strmsg = @"{Success:false,Msg:'删除失败'}";
                }                
            }
            object jsonobj = JsonConvert.DeserializeObject(strmsg);
            Context.Response.Write(jsonobj.ToString());
            Context.Response.End();
        }
    }
}
