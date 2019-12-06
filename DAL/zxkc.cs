using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using Common;

namespace DAL
{
    /// <summary>
    /// 专项扣除
    /// </summary>
    public partial class zxkc
    {
        public zxkc()
        { }
        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from t_zxkc order by id desc";
            object obj = DbHelperSql.GetSingle(conn, trans, strSql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_zxkc");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string empid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_zxkc");
            strSql.Append(" where empid=@empid");
            SqlParameter[] parameters = {
					new SqlParameter("@arlog", SqlDbType.VarChar,50)};
            parameters[0].Value = empid;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.zxkc model)
        {
            int newId;
            using (SqlConnection conn = new SqlConnection(DbHelperSql.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("insert into t_zxkc(");
                        strSql.Append("year,month,empid,name,znjy,jxjy,dbyl,zfdk,zfzj,sylr)");
                        strSql.Append(" values (");
                        strSql.Append("@year,@month,@empid,@name,@znjy,@jxjy,@dbyl,@zfdk,@zfzj,@sylr)");
                        SqlParameter[] parameters = {
					    new SqlParameter("@year", SqlDbType.VarChar,50),
					    new SqlParameter("@month", SqlDbType.VarChar,50),
					    new SqlParameter("@empid", SqlDbType.VarChar,50),
                        new SqlParameter("@name", SqlDbType.VarChar,50),
                        new SqlParameter("@znjy", SqlDbType.Decimal),
                        new SqlParameter("@jxjy",SqlDbType.Decimal),
                        new SqlParameter("@dbyl", SqlDbType.Decimal),
                        new SqlParameter("@zfdk",SqlDbType.Decimal),
                        new SqlParameter("@zfzj", SqlDbType.Decimal),
                        new SqlParameter("@sylr",SqlDbType.Decimal)};
                        parameters[0].Value = model.year;
                        parameters[1].Value = model.month;
                        parameters[2].Value = model.empid;
                        parameters[3].Value = model.name;
                        parameters[4].Value = model.znjy;
                        parameters[5].Value = model.jxjy;
                        parameters[6].Value = model.dbyl;
                        parameters[7].Value = model.zfdk;
                        parameters[8].Value = model.zfzj;
                        parameters[9].Value = model.sylr;

                        DbHelperSql.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        //取得新插入的ID
                        newId = GetMaxId(conn, trans);
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return -1;
                    }
                }
            }
            return newId;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.zxkc model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSql.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update t_zxkc set ");
                        strSql.Append("year=@year,");
                        strSql.Append("month=@month,");
                        strSql.Append("empid=@empid,");
                        strSql.Append("name=@name,");
                        strSql.Append("znjy=@znjy,");
                        strSql.Append("jxjy=@jxjy,");
                        strSql.Append("dbyl=@dbyl,");
                        strSql.Append("zfdk=@zfdk,");
                        strSql.Append("zfzj=@zfzj,");
                        strSql.Append("sylr=@sylr");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					    new SqlParameter("@year", SqlDbType.VarChar,50),
					    new SqlParameter("@month", SqlDbType.VarChar,50),
					    new SqlParameter("@empid", SqlDbType.VarChar,50),
                        new SqlParameter("@name", SqlDbType.VarChar,50),
                        new SqlParameter("@znjy", SqlDbType.Decimal),
                        new SqlParameter("@jxjy",SqlDbType.Decimal),
                        new SqlParameter("@dbyl", SqlDbType.Decimal),
                        new SqlParameter("@zfdk",SqlDbType.Decimal),
                        new SqlParameter("@zfzj", SqlDbType.Decimal),
                        new SqlParameter("@sylr",SqlDbType.Decimal),
                        new SqlParameter("@id",SqlDbType.Int,4)};

                        parameters[0].Value = model.year;
                        parameters[1].Value = model.month;
                        parameters[2].Value = model.empid;
                        parameters[3].Value = model.name;
                        parameters[4].Value = model.znjy;
                        parameters[5].Value = model.jxjy;
                        parameters[6].Value = model.dbyl;
                        parameters[7].Value = model.zfdk;
                        parameters[8].Value = model.zfzj;
                        parameters[9].Value = model.sylr;
                        parameters[10].Value = model.id;
                        DbHelperSql.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_zxkc ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 根据工号删除记录
        /// </summary>
        public bool Delete(string empid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_zxkc ");
            strSql.Append(" where empid=@empid");
            SqlParameter[] parameters = {
                    new SqlParameter("@empid", SqlDbType.VarChar,100)};
            parameters[0].Value = empid;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除选择年月记录
        /// </summary>
        public bool Delete(string year, string month)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_zxkc ");
            strSql.Append(" where year=@year and month=@month");
            SqlParameter[] parameters = {
                    new SqlParameter("@year", SqlDbType.VarChar,100),
                    new SqlParameter("@month", SqlDbType.VarChar,100)};
            parameters[0].Value = year;
            parameters[1].Value = month;

            int rows = DbHelperSql.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.zxkc GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,year,month,empid,name,znjy,jxjy,dbyl,zfdk,zfzj,sylr from t_zxkc ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.zxkc model = new Model.zxkc();
            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["year"] != null && ds.Tables[0].Rows[0]["year"].ToString() != "")
                {
                    model.year = ds.Tables[0].Rows[0]["year"].ToString();
                }
                if (ds.Tables[0].Rows[0]["month"] != null && ds.Tables[0].Rows[0]["month"].ToString() != "")
                {
                    model.month = ds.Tables[0].Rows[0]["month"].ToString();
                }
                if (ds.Tables[0].Rows[0]["empid"] != null && ds.Tables[0].Rows[0]["empid"].ToString() != "")
                {
                    model.empid = ds.Tables[0].Rows[0]["empid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["znjy"] != null && ds.Tables[0].Rows[0]["znjy"].ToString() != "")
                {
                    model.znjy =double.Parse(ds.Tables[0].Rows[0]["znjy"].ToString());
                }
                if (ds.Tables[0].Rows[0]["jxjy"] != null && ds.Tables[0].Rows[0]["jxjy"].ToString() != "")
                {
                    model.jxjy = double.Parse(ds.Tables[0].Rows[0]["jxjy"].ToString());  
                }
                if (ds.Tables[0].Rows[0]["dbyl"] != null && ds.Tables[0].Rows[0]["dbyl"].ToString() != "")
                {
                    model.dbyl = double.Parse(ds.Tables[0].Rows[0]["dbyl"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zfdk"] != null && ds.Tables[0].Rows[0]["zfdk"].ToString() != "")
                {
                    model.zfdk = double.Parse(ds.Tables[0].Rows[0]["zfdk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zfzj"] != null && ds.Tables[0].Rows[0]["zfzj"].ToString() != "")
                {
                    model.zfzj = double.Parse(ds.Tables[0].Rows[0]["zfzj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sylr"] != null && ds.Tables[0].Rows[0]["sylr"].ToString() != "")
                {
                    model.sylr = double.Parse(ds.Tables[0].Rows[0]["sylr"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,year,month,empid,name,znjy,jxjy,dbyl,zfdk,zfzj,sylr ");
            strSql.Append(" FROM t_zxkc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSql.Query(strSql.ToString());
        }

          /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT id,year,month,empid,name,cast(znjy as float) znjy,cast(jxjy as float) jxjy,cast(dbyl as float) dbyl,");
            strSql.Append(" cast(zfdk as float) zfdk, cast(zfzj as float) zfzj,cast(sylr as float) sylr, ");
            strSql.Append(" cast((znjy+jxjy+dbyl+zfdk+zfzj+sylr) as float) as total ");

            strSql.Append(" FROM t_zxkc ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by id,year,month,empid,name,znjy,jxjy,dbyl,zfdk,zfzj,sylr ");

            recordCount = Convert.ToInt32(DbHelperSql.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSql.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}
