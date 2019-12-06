using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;

namespace PITAX
{
    public partial class gsjs_list : System.Web.UI.Page
    {
        public int idx = 0;//显示序号
        public BLL.gsjs bll = new BLL.gsjs();

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
            rpt_list.DataSource = bll.GetList1(this.pagesize, this.page, whereStr, " id asc", out this.totalCount);
            rpt_list.DataBind();
            txtTotalCount.InnerText = totalCount.ToString();//绑定总记录数

            txt_bygsCount.InnerText = bll.taxCount(this.year,this.month).ToString();
            //txtPageNum.Text = this.pagesize.ToString();//绑定页码
            // txtPageNum.InnerText = this.pagesize.ToString();//绑定页码
            string pageUrl = Common.Utils.CombUrlTxt("gsjs_list.aspx", "year={0}&month={1}&empid={2}&page={3}", this.year, this.month, this.emp_id, "__id__");
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
            if (int.TryParse(Common.Utils.GetCookie("gsjs_page_size"), out pageSize))
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
            Response.Redirect(Common.Utils.CombUrlTxt("gsjs_list.aspx", "year={0}&month={1}&empid={2}",
             slt_year.SelectedValue, slt_month.SelectedValue, empid.Text));
        }

        /// <summary>
        ///  生成一个报表
        /// </summary>
        protected void btn_report_Click(object sender, EventArgs e)
        {
            strStatus.InnerText = "";
            string year = slt_year.SelectedValue;
            string month = slt_month.SelectedValue;

            /* if (!(year==DateTime.Now.AddMonths(-1).Year.ToString()&&month==DateTime.Now.AddMonths(-1).Month.ToString()))
            {
                strStatus.InnerText = "只能生成上月个税报表";
                return;
            }*/            

            bll.Delete(year, month);//删除选择月个税数据后重新生成

            //获取选择月数据
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT c.id,c.year,c.month,c.depart,c.departid,c.empid,c.name,c.gzjb,c.yfje,c.kk,c.gjj,c.bxkk,c.zxkc,c.jckk ");
            strSql.Append(" ,(c.gjj+c.bxkk+c.zxkc+c.jckk) as total ");
            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT a.id,a.depart,a.departid,a.year,a.month, a.empid,a.name,a.gzjb,a.yfje,(a.kqtk+a.kk+a.gsk) as kk,(a.gjj-a.gjj2) as gjj,a.bxkk,");
            strSql.Append(" ISNULL((b.znjy+b.jxjy+b.dbyl+b.zfdk+b.zfzj+b.sylr),0) as zxkc,5000 as jckk");
            strSql.Append("  FROM t_gzmx a ");
            strSql.Append(" LEFT JOIN t_zxkc b ");
            strSql.Append(" on a.empid=b.empid and a.year=b.year and a.month=b.month ");
            //strSql.Append(" where a.year='2019' and a.month='2' ");
            strSql.Append(" group by a.id,a.depart,a.departid, a.year,a.month, a.empid,a.name,a.gzjb,a.yfje,a.kqtk,a.kk,a.gsk,a.gjj2,a.gjj,a.bxkk, ");
            strSql.Append(" b.znjy,b.jxjy,b.dbyl,b.zfdk,b.zfzj,b.sylr ");
            strSql.Append(" ) c ");
            strSql.Append(" where c.year='"+year+"' and c.month='"+month+"' ");
            strSql.Append(" group by c.id,c.depart,c.departid,c.year,c.month,c.empid,c.name,c.gzjb,c.yfje,c.kk,c.gjj,c.bxkk,c.zxkc,c.jckk ");

            double ysgz ; //本月应缴个税工资

            SqlDataReader reader = DBUtility.DbHelperSql.ExecuteReader(strSql.ToString());
            while (reader.Read())
            {
                ysgz = 0;

                Model.gsjs model = new Model.gsjs();
                model.year = year;
                model.month = month;
                model.depart = reader["depart"].ToString();
                model.departid = reader["departid"].ToString();
                model.empid = reader["empid"].ToString();
                model.name = reader["name"].ToString();
                model.gzjb = reader["gzjb"].ToString();
                model.yfje = double.Parse(reader["yfje"].ToString());
                model.kk = double.Parse(reader["kk"].ToString());
                model.gjj = double.Parse(reader["gjj"].ToString());
                model.bxkk = double.Parse(reader["bxkk"].ToString());
                model.zxkk = double.Parse(reader["zxkc"].ToString());
                model.jckk = double.Parse(reader["jckk"].ToString());
                //计算本年累计应税工资，如果是1月份：应发工资-扣除-专项扣除-五险一金-5000基本扣除
                // 生成月分不为1月份时： 应发工资-扣除-专项扣除-五险一金-5000基本扣除+ 上月全年累计应税工资
                if (month == "1")
                {
                    ysgz = double.Parse(reader["yfje"].ToString()) - double.Parse(reader["total"].ToString());//本月应缴个税
                   // model.ysgzlj = ysgz > 0 ? ysgz : 0; //本年应缴个税工资累计
                    model.ysgzlj = ysgz; //本年应缴个税工资累计
                    model.gslj = Common.PITTotal.PITSum(ysgz > 0 ? ysgz : 0); //本年度应缴个税累计
                    model.bygs = Common.PITTotal.PITSum(ysgz > 0 ? ysgz : 0); //本月应缴个税
                }
                else
                {
                    ysgz = double.Parse(reader["yfje"].ToString()) - double.Parse(reader["total"].ToString());//本月应缴个税
                    //获取上月年度应缴工资累计、个税累计
                    Model.gsjs topMonthModel = bll.GetModel(year, (int.Parse(month) - 1).ToString(), reader["empid"].ToString());
                    if (topMonthModel != null)
                    {
                        double ysgzlj=0;// 本年度应缴个税总额
                        double syndgs = 0; //上月年度应缴个总额个税计算
                        double byndgs = 0; //本月年度个税
                        //年度应缴个税工资累计
                        ysgzlj = ysgz + topMonthModel.ysgzlj; //本年应缴个税工资累计
                        model.ysgzlj = ysgzlj;

                       //计算本年度个税累计
                        syndgs = topMonthModel.gslj;//Common.PITTotal.PITSum(topMonthModel.ysgzlj>0?topMonthModel.ysgzlj:0); //上月年度应缴个税                        
                        byndgs = Common.PITTotal.PITSum(ysgzlj > 0 ? ysgzlj : 0); //本月年度应缴个税
                        model.gslj =topMonthModel.gslj+ ((byndgs - syndgs) > 0 ? byndgs - syndgs : 0);


                        model.bygs = (byndgs - syndgs)>0 ? byndgs - syndgs : 0; 




                        //model.ysgzlj = (ysgz > 0 ? ysgz : 0) + topMonthModel.ysgzlj; //本年应缴个税工资累计
                      //  model.ysgzlj = ysgz + topMonthModel.ysgzlj; //本年应缴个税工资累计
                      //  model.gslj = Common.PITTotal.PITSum((ysgz + topMonthModel.ysgzlj) > 0 ? (ysgz + topMonthModel.ysgzlj) : 0);//本年度应缴个税累计
                        //当月个税=本年应缴个税累计-上月本年应缴个税累计
                       // model.bygs = Common.PITTotal.PITSum((ysgz + topMonthModel.ysgzlj) > 0 ? (ysgz + topMonthModel.ysgzlj) : 0) - topMonthModel.gslj; 
                    }
                    else
                    { 
                        //如果员工新入职获取上个月的工资报表为空，则当月开始累计
                       // model.ysgzlj = ysgz > 0 ? ysgz : 0; //本年应缴个税工资累计
                        model.ysgzlj = ysgz; //本年应缴个税工资累计
                        model.gslj = Common.PITTotal.PITSum(ysgz > 0 ? ysgz : 0); //本年度应缴个税累计
                        model.bygs = Common.PITTotal.PITSum(ysgz > 0 ? ysgz : 0); //本月应缴个税
                    }
                }
                bll.Add(model);

            }
            reader.Close();
            strStatus.InnerText = slt_year.SelectedValue + "年" + slt_month.SelectedValue + "月个税报表已生成。";

        }
        /// <summary>
        ///  导出一个报表
        /// </summary>
        protected void btn_reportimprot_Click(object sender, EventArgs e)
        {
            //数据导入到EXCEL表格中，并保存在服务器excel文件夹中
            string file = Server.MapPath("excel/") + slt_year.SelectedValue + "年" + slt_month.SelectedValue + "月个税报表.xls";// @"C:\Users\liga\Downloads\" + slt_year.SelectedValue + "年" + slt_month.SelectedValue + "月个税报表.xls";
            DataTable dt = new DataTable();
            dt = bll.GetList(0, " year='" + slt_year.SelectedValue + "' and month='" + slt_month.SelectedValue + "' ", " id asc").Tables[0];
            TableToExcel(dt, file);

            //文件导出到客户端下载并保存
            FileInfo fileInfo = new FileInfo(file);
            Response.Clear();
            Response.Charset = "GB2312";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(fileInfo.Name));
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.ContentType = "application/x-bittorrent";
            Response.WriteFile(fileInfo.FullName);            
            
        }
        /// <summary>
        /// Datable导出成Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="file">导出路径(包括文件名与扩展名)</param>
        public void TableToExcel(DataTable dt, string file)
        {
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx") 
            { 
                workbook = new XSSFWorkbook(); 
            } 
            else if (fileExt == ".xls") 
            { 
                workbook = new HSSFWorkbook(); 
            } 
            else { 
                workbook = null; 
            }
            if (workbook == null) 
            { 
                return; 
            }
            //ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(dt.TableName);

            ISheet sheet = string.IsNullOrEmpty(dt.TableName) ? workbook.CreateSheet("Sheet1") : workbook.CreateSheet(slt_year.SelectedValue + "年" + slt_month.SelectedValue + "月");

            //表头  
            IRow row = sheet.CreateRow(0);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
            }

            //数据  
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IRow row1 = sheet.CreateRow(i + 1);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    cell.SetCellValue(dt.Rows[i][j].ToString());
                }
            }

            //转为字节数组  
            MemoryStream stream = new MemoryStream();
            workbook.Write(stream);
            var buf = stream.ToArray();

            //保存为Excel文件  
            using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                fs.Write(buf, 0, buf.Length);
                fs.Flush();
            }
           
        }

    }
}