using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BLL
{
    /// <summary>
    /// 工资明细
    /// </summary>
    public partial class gzmx
    {
        private readonly DAL.gzmx dal = new DAL.gzmx();
        public gzmx()
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
        public int Add(Model.gzmx model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.gzmx model)
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
        /// 根据工号删除数据
        /// </summary>
        public bool Delete(string empid)
        {
            return dal.Delete(empid);
        }
        /// <summary>
        /// 根据年月删除数据
        /// </summary>
        public bool Delete(string year, string month)
        {
            return dal.Delete(year, month);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.gzmx GetModel(int id)
        {
            return dal.GetModel(id);
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

        #endregion  Method
    }
}
