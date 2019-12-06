using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PITAX
{
    /// <summary>
    /// HandlerLo   gin 的摘要说明
    /// </summary>
    public class HandlerLogin : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
           {
            string username = Common.DTRequest.GetFormString("  ");
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
                //strmsg = "{\"Success\":false,\"Msg\":\"用户名不存在！\"}";
                   strmsg = @"{Success:false,Msg:'用户名不存在'}";
             } 
            object objjson = JsonConvert.DeserializeObject(strmsg); 
            context.Response.ContentType = "text/plain"; 
            context.Response.Write(objjson.ToString());
            context.Response.End();  
            // context.Response.ContentType = "text/plain";
            // context.Response.Write("Hello World");
        }

        public bool IsReusable   
        {
             get
               {
                return false;
            }
        }
    } 
}   