using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;


namespace PITAX
{
    public partial class gzmx_upload : System.Web.UI.Page
    {
        protected BLL.gzmx bll = new BLL.gzmx(); //新建BLL数据处理对像
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YearBind();
                MonthBind();
                slt_year.Value = DateTime.Now.AddMonths(-1).Year.ToString();
                slt_month.Value = DateTime.Now.AddMonths(-1).Month.ToString();
            }
        }
        /// <summary>
        /// 绑定年份
        /// </summary>
        private void YearBind()
        {
            for (int i = 2019; i <= DateTime.Now.Year; i++)
            {
                slt_year.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        /// <summary>
        /// 绑定月份
        /// </summary>
        private void MonthBind()
        {
            for (int i = 1; i <= 12; i++)
            {
                slt_month.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            string year = slt_year.Value;
            string month = slt_month.Value;

            /* if (!(year==DateTime.Now.AddMonths(-1).Year.ToString()&&month==DateTime.Now.AddMonths(-1).Month.ToString()))
            {
                strStatus.InnerText = "只能导入上月工资明细数据。";
                return;
            }*/           

            SaveExcels();
        }
        /// <summary>
        ///  EXCEL文件保存到服务器端，并上传到AS400中
        /// </summary>
        protected void SaveExcels()
        {
            StringBuilder strMsg = new StringBuilder(); //状态信息  
            string fileName = Path.GetFileName(fud_fileName.PostedFile.FileName);
            string fileExtension = Path.GetExtension(fud_fileName.PostedFile.FileName);
            string newfileName = "";

            if (fileExtension == ".xls" || fileExtension == ".xlsx") //判断文件名的后缀
            {
                strMsg.Append("上传的文件客户端文件地址：" + fud_fileName.PostedFile.FileName);
                ///可根据扩展名字的不同保存到不同的文件夹  
                ///注意：可能要修改你的文件夹的匿名写入权限。
                fud_fileName.SaveAs(System.Web.HttpContext.Current.Request.MapPath("Excel/") + fileName);
                // postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("Excel/") + fileName);
                // HttpFileName.Add(iFile, fileName);
                newfileName = fileName;
            }
            else
            {
                strMsg.Append("上传文件：" + fileName + " 扩展名不正确，请选择正确的文件类型");
            }
            strStatus.InnerText = strMsg.ToString();
            if (newfileName != "")
            {
                bll.Delete(slt_year.Value, slt_month.Value);//删除选择月数据
                ExcelFileUpload(System.Web.HttpContext.Current.Request.MapPath("excel/"), fileName);
            }          

        }
        /// <summary>
        /// excel文件导入
        /// </summary>
        /// <param name="excelFilePath">excel文件路径</param>
        /// <param name="fileName">文件名</param>
        public void ExcelFileUpload(string excelFilePath, string fileName)
        {
            IWorkbook workbook = null;  //新建IWorkbook对象             
            FileStream fileStream = new FileStream(excelFilePath + fileName, FileMode.Open, FileAccess.Read);
            if (fileName.IndexOf(".xlsx") > 0) // 2007版本  
            {
                workbook = new XSSFWorkbook(fileStream);  //xlsx数据读入workbook  
            }
            else if (fileName.IndexOf(".xls") > 0) // 2003版本  
            {
                workbook = new HSSFWorkbook(fileStream);  //xls数据读入workbook  
            }
            for (int s = 0; s < workbook.NumberOfSheets; s++) //遍历所有工作簿
            {
                ISheet sheet = workbook.GetSheetAt(s);  //获取工作表  

                IRow row;// = sheet.GetRow(0);            //新建当前工作表行数据 

                for (int i = 2; i < sheet.LastRowNum; i++)  //从第3行开始读取EXCEL工作簿表格每行
                {
                    row = sheet.GetRow(i);   //row读入第i行数据  

                    if (row == null)//如果A列数据为空，退出循环
                    {
                        break;
                    }
                    else
                    {
                        if (row.GetCell(0).ToString() == "TOTAL")//如果A列数据为空，退出循环
                        {
                            break;
                        }
                    }
                    if (row != null) // 行不为空时，对数据进行处理
                    {

                            Model.gzmx model = new Model.gzmx(); //新建zxkc数据模型对像
                            model.year = slt_year.Value;
                            model.month = slt_month.Value;
                            model.depart = GetStringValue(row.GetCell(0));
                            model.departid = GetStringValue(row.GetCell(1));
                            model.empid = GetStringValue(row.GetCell(3));
                            model.name = GetStringValue(row.GetCell(2));
                            model.gzjb = ""; //GetStringValue(row.GetCell(4));
                            model.yfje = row.GetCell(4).NumericCellValue;//GetDoubleValue(row.GetCell(3).StringCellValue);
                            model.kqtk = row.GetCell(5).NumericCellValue; //GetDoubleValue(row.GetCell(4));
                            model.kk = row.GetCell(6).NumericCellValue; //GetDoubleValue(row.GetCell(5));
                            model.gsk = row.GetCell(7).NumericCellValue; //GetDoubleValue(row.GetCell(6));
                            model.gjj2 = row.GetCell(8).NumericCellValue; //GetDoubleValue(row.GetCell(7));
                            model.gjj = row.GetCell(9).NumericCellValue; //GetDoubleValue(row.GetCell(8));
                            model.bxkk = row.GetCell(10).NumericCellValue; //GetDoubleValue(row.GetCell(7));
                            model.sfje = row.GetCell(12).NumericCellValue; //GetDoubleValue(row.GetCell(8));
                            bll.Add(model);
                     

                    }
                }

            }
            fileStream.Close();
            workbook.Close();

        }

        /// <summary>
        ///  excel表格数据项为空时， 进行转换
        /// </summary>
        private double GetDoubleValue(object obj)
        {
            return obj == null ? 0 : Math.Round(double.Parse(obj.ToString()), 2);
        }

        /// <summary>
        ///  excel表格数据项为空时， 进行转换
        /// </summary>
        private double GetDoubleValue(string cellString)
        {
            if (string.IsNullOrEmpty(cellString))
            {
                return 0;
            }
            return Math.Round(double.Parse(cellString), 2);
        }

        /// <summary>
        ///  excel表格数据项为空时， 进行转换
        /// </summary>
        private string GetStringValue(object obj)
        {
            return obj == null ? "" : obj.ToString();
        }

        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;
            }
        }

    }
}