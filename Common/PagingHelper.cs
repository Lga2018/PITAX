using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    /// <summary>
    /// 对页面进行分面，SQL类
    /// </summary>
    public static class PagingHelper
    {
        /// <summary>
        /// 获取分页SQL语句，排序字段需要构成唯一记录
        /// </summary>
        /// <param name="_recordCount">记录总数</param>
        /// <param name="_pageSize">每页记录数</param>
        /// <param name="_pageIndex">当前页数</param>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <param name="_orderField">排序字段，多个则用“,”隔开</param>
        /// <returns>分页SQL语句</returns>
        public static string CreatePagingSql(int _recordCount, int _pageSize, int _pageIndex, string _safeSql, string _orderField)
        {
            //重新组合排序字段，防止有错误
            string[] arrStrOreders = _orderField.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sbOriginalOrder = new StringBuilder(); //原排序字段
            StringBuilder sbReverseOrder = new StringBuilder();//与原排序字段相反
            for (int i = 0; i < arrStrOreders.Length; i++)
            {
                arrStrOreders[i] = arrStrOreders[i].Trim();//去除前后空格
                if (i != 0)
                {
                    sbOriginalOrder.Append(", ");
                    sbReverseOrder.Append(", ");
                }
                sbOriginalOrder.Append(arrStrOreders[i]);
                int index = arrStrOreders[i].IndexOf(" "); //判断是否有升降序标识
                if (index > 0)
                {
                    bool flag = arrStrOreders[i].IndexOf(" DESC", StringComparison.OrdinalIgnoreCase) != -1;
                    sbReverseOrder.AppendFormat("{0} {1}", arrStrOreders[i].Remove(index), flag ? "ASC" : "DESC");
                }
                else
                {
                    sbReverseOrder.AppendFormat(" {0} DESC", arrStrOreders[i]);
                }
            }
            //计算总页数
            _pageSize = _pageSize == 0 ? _recordCount : _pageSize;
            int pageCount = (_recordCount + _pageSize - 1) / _pageSize;

            //当前页数
            if (_pageIndex < 1)
            {
                _pageIndex = 1;
            }
            else if (_pageIndex > pageCount)
            {
                _pageIndex = pageCount;
            }

            StringBuilder sbSql = new StringBuilder();

            if (_pageIndex == 1) //第一页时
            {
                sbSql.AppendFormat("SELECT TOP {0} *", _pageSize);
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                sbSql.AppendFormat(" ORDER BY {0}", sbOriginalOrder);
            }
            else if (_pageIndex == pageCount)//最后一页时
            {
                sbSql.Append(" SELECT * FROM ");
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} *", _recordCount - _pageSize * (_pageIndex - 1));
                sbSql.AppendFormat(" FROM ({0}) AS T", _safeSql);
                sbSql.AppendFormat(" ORDER BY {0}", sbReverseOrder);
                sbSql.Append(" ) AS T");
                sbSql.AppendFormat(" ORDER BY {0}", sbOriginalOrder);
            }

            else if (_pageIndex <= (pageCount / 2 + pageCount % 2) + 1) //前半页分页
            {
                sbSql.Append(" SELECT * FROM ");
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * FROM ", _pageSize);
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * ", _pageSize * _pageIndex);
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
                sbSql.Append(" ) AS T ");
                sbSql.AppendFormat(" ORDER BY {0} ", sbReverseOrder.ToString());
                sbSql.Append(" ) AS T ");
                sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());
            }
            else//后面页分页
            {
                sbSql.AppendFormat(" SELECT TOP {0} * FROM ", _pageSize);
                sbSql.Append(" ( ");
                sbSql.AppendFormat(" SELECT TOP {0} * ", ((_recordCount % _pageSize) + _pageSize * (pageCount - _pageIndex) + 1));
                sbSql.AppendFormat(" FROM ({0}) AS T ", _safeSql);
                sbSql.AppendFormat(" ORDER BY {0} ", sbReverseOrder.ToString());
                sbSql.Append(" ) AS T ");
                sbSql.AppendFormat(" ORDER BY {0} ", sbOriginalOrder.ToString());

            }
            return sbSql.ToString();
        }
        /// <summary>
        /// 获取记录总数SQL语句
        /// </summary>
        /// <param name="_safeSql">SQL查询语句</param>
        /// <returns>记录总数SQL语句</returns>
        public static string CreateCountingSql(string _safeSql)
        {
            return string.Format(" SELECT COUNT(1) AS RecordCount FROM ({0}) AS T ", _safeSql);
        }
    }
}
