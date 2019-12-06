using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 专项扣除
    /// </summary>
   public class zxkc
    {
        public zxkc()
        { }
        #region Model
        private int _id;
        private string _year="";
        private string _month="";
        private string _empid="";
        private string _name="";
        private double _znjy=0;
        private double _jxjy=0;
        private double _dbyl = 0;
        private double _zfdk = 0;
        private double _zfzj = 0;
        private double _sylr = 0;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 年份
        /// </summary>
        public string year
        {
            set { _year = value; }
            get { return _year; }
        }
        /// <summary>
        /// 月份
        /// </summary>
        public string month
        {
            set { _month = value; }
            get { return _month; }
        }
        /// <summary>
        /// 工号
        /// </summary>
        public string empid
        {
            set { _empid = value; }
            get { return _empid; }
        }
        /// <summary>
        /// 月份
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        
        }
        /// <summary>
        /// 子女教育
        /// </summary>
        public double znjy
        {
            get { return _znjy; }
            set { _znjy = value; }
        }
        /// <summary>
        /// 继续教育
        /// </summary>
        public double jxjy
        {
            set { _jxjy = value; }
            get { return _jxjy; }
        }
         /// <summary>
        /// 大病医疗
        /// </summary>
        public double dbyl
        {
            get { return _dbyl; }
            set { _dbyl = value; }
        }
        /// <summary>
        /// 住房贷款
        /// </summary>
        public double zfdk
        {
            set { _zfdk = value; }
            get { return _zfdk; }
        }
         /// <summary>
        /// 住房租金
        /// </summary>
        public double zfzj
        {
            get { return _zfzj; }
            set { _zfzj = value; }
        }
        /// <summary>
        /// 赡养老人
        /// </summary>
        public double sylr
        {
            set { _sylr = value; }
            get { return _sylr; }
        }
        #endregion Model
    }
}
