using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 计算个税
    /// </summary>
    public partial class gsjs
    {
        private readonly DAL.gsjs dal = new DAL.gsjs();
        public gsjs()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string empid)
        {
            return dal.Exists(empid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.gsjs model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.gsjs model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        /// <summary>
        /// 删除当月数据
        /// </summary>
        public bool Delete(string year,string month)
        {
            return dal.Delete(year,month);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.gsjs GetModel(int id)
        {
            return dal.GetModel(id);
        }
        /// <summary>
        ///  得到一个对像实体
        /// </summary>
        public Model.gsjs GetModel(string year, string month, string empid)
        {
            return dal.GetModel(year, month, empid);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public DataSet GetList1(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList1(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 获取当月个税汇总
        /// </summary>
        public double taxCount(string year, string month)
        {
            return dal.taxCount(year, month);
        }

        #endregion  Method
    }
}
