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
    public partial class zxkc_upload : System.Web.UI.Page
    {
        protected BLL.zxkc bll = new BLL.zxkc(); //新建BLL数据处理对像
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YearBind();
                MonthBind();
                slt_year.Value =DateTime.Now.AddMonths(-1).Year.ToString();
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
                slt_year.Items.Add(new ListItem(i.ToString(),i.ToString()));
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
                strStatus.InnerText = "只能导入上月传项扣除数据。";
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
            string fileName =Path.GetFileName(fud_fileName.PostedFile.FileName);
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


         /*   HttpFileCollection files = HttpContext.Current.Request.Files; //遍历File表单元素 ,POST方式提交数据 

            Hashtable HttpFileName = new Hashtable();// 保存上传文件名
            HttpFileName.Clear();

            StringBuilder strMsg = new StringBuilder(); //状态信息  
            strMsg.Append("上传的文件：");
            try
            {
                for (int iFile = 0; iFile < files.Count; iFile++)
                {
                    //检查文件扩展名字  
                    HttpPostedFile postedFile = files[iFile];
                    string fileName, fileExtension;
                    fileName = System.IO.Path.GetFileName(postedFile.FileName); //根据文件路径判断文件名
                    if (fileName != "")
                    {
                        fileExtension = System.IO.Path.GetExtension(fileName); //获取文件后缀
                        if (fileExtension == ".xls" || fileExtension == ".xlsx") //判断文件名的后缀
                        {
                            strMsg.Append("客户端文件地址：" + postedFile.FileName + "<br>");
                            strMsg.Append("上传文件的文件名：" + fileName + "<br>");
                            ///可根据扩展名字的不同保存到不同的文件夹  
                            ///注意：可能要修改你的文件夹的匿名写入权限。  
                            postedFile.SaveAs(System.Web.HttpContext.Current.Request.MapPath("Excel/") + fileName);
                            HttpFileName.Add(iFile, fileName);
                        }
                        else
                        {
                            strMsg.Append("上传文件：" + fileName + " 扩展名不正确，请选择正确的文件类型");
                        }

                    }
                }
                strStatus.InnerText = strMsg.ToString();
            }
            catch (System.Exception Ex)
            {
                strStatus.InnerText = Ex.Message;
                return;
            }

            foreach (DictionaryEntry FileName in HttpFileName)//循环读取上传到服务器的表格并导入到数据库中
            {
                ExcelFileUpload(System.Web.HttpContext.Current.Request.MapPath("excel/"), FileName.Value.ToString());
            }*/
            
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

                for (int i = 3; i < sheet.LastRowNum; i++)  //从第3行开始读取EXCEL工作簿表格每行
                {
                    row = sheet.GetRow(i);   //row读入第i行数据  

                    if (row == null)//如果A列数据为空，退出循环
                    {
                        break;
                    }
                    else
                    {
                        if (row.GetCell(0).ToString() == "")//如果A列数据为空，退出循环
                        {
                            break;
                        }
                    }
                    if (row != null) // 行不为空时，对数据进行处理
                    {
                        try
                        {
                            Model.zxkc model = new Model.zxkc(); //新建zxkc数据模型对像
                            model.year = slt_year.Value;
                            model.month = slt_month.Value;
                            model.empid = GetStringValue(row.GetCell(1));
                            model.name = GetStringValue(row.GetCell(2));
                            model.znjy = row.GetCell(3).NumericCellValue;//GetDoubleValue(row.GetCell(3).StringCellValue);
                            model.jxjy = row.GetCell(4).NumericCellValue; //GetDoubleValue(row.GetCell(4));
                            model.zfdk = row.GetCell(5).NumericCellValue; //GetDoubleValue(row.GetCell(5));
                            model.zfzj = row.GetCell(6).NumericCellValue; //GetDoubleValue(row.GetCell(6));
                            model.sylr = row.GetCell(7).NumericCellValue; //GetDoubleValue(row.GetCell(7));
                            model.dbyl = row.GetCell(8).NumericCellValue; //GetDoubleValue(row.GetCell(8));
                            bll.Add(model);
                        }
                        catch (Exception e)
                        {
                            strStatus.InnerText = "上传的文件： " + fileName + " 第" + (i + 1).ToString() + "行格式错误！请检查后重新上传";
                        }

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
            return obj == null ? "" :obj.ToString();
        }
    }
}