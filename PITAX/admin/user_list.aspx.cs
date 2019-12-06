using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace PITAX.admin
{
    public partial class user_list : System.Web.UI.Page
    {
        public int idx = 0;//显示序号
        public BLL.users bll = new BLL.users();

        protected int totalCount; //总记录条数
        protected int page;//页面数
        protected int pagesize;//每页记录条数

        protected void Page_Load(object sender, EventArgs e)
        {
            pagesize = GetPageSize(20); //每面数据
            string action = Request.QueryString["action"];
            if (!IsPostBack)
            {
                RptBind("1=1 " + CombSqlTxt("","",""));
            }

            if (!string.IsNullOrEmpty(action))
            {
                string id = Request.QueryString["ID"];
                bll.Delete(int.Parse(id));
            }

        }
        /// <summary>
        /// 数据列表绑定
        /// </summary>
        private void RptBind(string whereStr)
        {
            //绑定数据
            this.page = Common.Utils.GetQueryInt("page", 1);
            rpt_list.DataSource = bll.GetList(this.pagesize, this.page, whereStr, " id asc", out this.totalCount);
            rpt_list.DataBind();
            txtTotalCount.InnerText = totalCount.ToString();//绑定总记录数
            //txtPageNum.Text = this.pagesize.ToString();//绑定页码
            // txtPageNum.InnerText = this.pagesize.ToString();//绑定页码
            string pageUrl = Common.Utils.CombUrlTxt("user_list.aspx", "page={0}","__id__");
            PageContent.InnerHtml = Common.Utils.OutPageList(this.pagesize, this.page, this.totalCount, pageUrl, 8);

        }
        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _year, string _month, string _empid)
        {
            StringBuilder strTemp = new StringBuilder();
            _year = _year.Replace("'", "");
            _month = _month.Replace("'", "");
            _empid = _empid.Replace("'", "");
            if (!string.IsNullOrEmpty(_year))
            {
                strTemp.Append(" and year='" + _year + "'");
     namespace            }
            if (!string.IsNullOrEmpty(_month))
            {
                strTemp.Append(" and month='" + _month + "'");
              }
            if (!string.IsNullOrEmpty(_empid))
            {
                strTemp.Append(" and empid='" + _empid + "'");
            }
            return strTemp.ToString();
        }
        #endregion
        /// <summary>
        /// 返回页面每页的数据
        /// </summary>
        /// <param name="defaultSize">默认页面数量</param>
        /// <returns>页面数量</returns>
        private int GetPageSize(int defaultSize)
        {
            int pageSize;
            if (int.TryParse(Common.Utils.GetCookie("users_page_size"), out pageSize))
            {
                if (pagesize > 0)
                {
                    return pagesize;
                }
            }
            return defaultSize;
        }
    }
}