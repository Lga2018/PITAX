using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace PITAX
{
    public partial class gzmx_list : System.Web.UI.Page
    {
        public int idx = 0;//显示序号
        public BLL.gzmx bll = new BLL.gzmx();

        protected int totalCount; //总记录条数
        protected int page;//页面数
        protected int pagesize;//每页记录条数

        protected string year = string.Empty;
        protected string month = string.Empty;
        protected string emp_id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.year = Common.DTRequest.GetQueryString("year");
            this.month = Common.DTRequest.GetQueryString("month");
            this.emp_id = Common.DTRequest.GetQueryString("empid");

            pagesize = GetPageSize(20); //每面数据
            string action = Request.QueryString["action"];
            if (!IsPostBack)
            {
                YearMonthBind();
                if (string.IsNullOrEmpty(this.year))
                {
                    this.year = slt_year.SelectedValue;
                }
                if (string.IsNullOrEmpty(this.month))
                {
                    this.month = slt_month.SelectedValue;
                }
                RptBind("1=1 " + CombSqlTxt(this.year, this.month, this.emp_id));
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
            if (!string.IsNullOrEmpty(this.year))
            {
                slt_year.SelectedValue = this.year;
            }
            if (!string.IsNullOrEmpty(this.month))
            {
                slt_month.SelectedValue = this.month;
            }
            empid.Text = this.emp_id;
            rpt_list.DataSource = bll.GetList(this.pagesize, this.page, whereStr, " id asc", out this.totalCount);
            rpt_list.DataBind();
            txtTotalCount.InnerText = totalCount.ToString();//绑定总记录数
            //txtPageNum.Text = this.pagesize.ToString();//绑定页码
            // txtPageNum.InnerText = this.pagesize.ToString();//绑定页码
            string pageUrl = Common.Utils.CombUrlTxt("gzmx_list.aspx", "year={0}&month={1}&empid={2}&page={3}", this.year, this.month, this.emp_id, "__id__");
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
            }
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
            if (int.TryParse(Common.Utils.GetCookie("gzmx_page_size"), out pageSize))
            {
                if (pagesize > 0)
                {
                    return pagesize;
                }
            }
            return defaultSize;
        }
        /// <summary>
        /// 绑定年份
        /// </summary>
        private void YearMonthBind()
        {
            if (slt_year.Items.Count == 0)
            {
                int i = 0;
                for (i = 2019; i <= DateTime.Now.Year; i++)
                {
                    slt_year.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                for (i = 1; i <= 12; i++)
                {
                    slt_month.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                slt_year.SelectedValue = DateTime.Now.AddMonths(-1).Year.ToString();
                slt_month.SelectedValue = DateTime.Now.AddMonths(-1).Month.ToString();
            }
        }  

        protected void btn_sreach_Click(object sender, EventArgs e)
        {
            Response.Redirect(Common.Utils.CombUrlTxt("gzmx_list.aspx", "year={0}&month={1}&empid={2}",
             slt_year.SelectedValue, slt_month.SelectedValue, empid.Text));
        }
    }
}