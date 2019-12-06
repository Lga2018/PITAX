using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 工资明细
    /// </summary>
    public class gzmx
    {
        public gzmx()
        { }
        #region Model
        private int _id;
        private string _year = "";
        private string _month = "";
        private string _depart = "";
        private string _departid = "";
        private string _empid = "";
        private string _name = "";
        private string _gzjb = "";
        private double _yfje = 0;
        private double _kqtk = 0;
        private double _kk = 0;
        private double _gsk = 0;
        private double _gjj2 = 0;
        private double _gjj = 0;
        private double _bxkk = 0;
        private double _sfje = 0;
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
        /// 部门
        /// </summary>
        public string depart
        {
            set { _depart = value; }
            get { return _depart; }
        }
        /// <summary>
        /// 部门代码
        /// </summary>
        public string departid
        {
            set { _departid = value; }
            get { return _departid; }
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
        /// 工资级别
        /// </summary>
        public string gzjb
        {
            get { return _gzjb; }
            set { _gzjb = value; }
        }
        /// <summary>
        /// 应发金额
        /// </summary>
        public double yfje
        {
            get { return _yfje; }
            set { _yfje = value; }
        }
        /// <summary>
        /// 扣其它款
        /// </summary>
        public double kqtk
        {
            set { _kqtk = value; }
            get { return _kqtk; }
        }
        /// <summary>
        /// 捐款
        /// </summary>
        public double kk
        {
            get { return _kk; }
            set { _kk = value; }
        }
        /// <summary>
        /// 工伤扣
        /// </summary>
        public double gsk
        {
            set { _gsk = value; }
            get { return _gsk; }
        }
        /// <summary>
        /// 公积金2
        /// </summary>
        public double gjj2
        {
            get { return _gjj2; }
            set { _gjj2 = value; }
        }
        /// <summary>
        /// 公积金
        /// </summary>
        public double gjj
        {
            set { _gjj = value; }
            get { return _gjj; }
        }
        /// <summary>
        /// 保险扣款
        /// </summary>
        public double bxkk
        {
            set { _bxkk = value; }
            get { return _bxkk; }
        }
        /// <summary>
        /// 实发金额
        /// </summary>
        public double sfje
        {
            set { _sfje = value; }
            get { return _sfje; }
        }
        #endregion Model
    }
}
