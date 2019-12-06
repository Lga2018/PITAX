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
    /// 工资明细
    /// </summary>
    public partial class gzmx
    {
        public gzmx()
        { }
        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from t_gzmx order by id desc";
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
            strSql.Append("select count(1) from t_gzmx");
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
            strSql.Append("select count(1) from t_gzmx");
            strSql.Append(" where empid=@empid");
            SqlParameter[] parameters = {
					new SqlParameter("@empid", SqlDbType.VarChar,50)};
            parameters[0].Value = empid;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.gzmx model)
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
                        strSql.Append("insert into t_gzmx(");
                        strSql.Append("year,month,depart,departid,empid,name,gzjb,yfje,kqtk,kk,gsk,gjj2,gjj,bxkk,sfje)");
                        strSql.Append(" values (");
                        strSql.Append("@year,@month,@depart,@departid,@empid,@name,@gzjb,@yfje,@kqtk,@kk,@gsk,@gjj2,@gjj,@bxkk,@sfje)");
                        SqlParameter[] parameters = {
					    new SqlParameter("@year", SqlDbType.VarChar,50),
					    new SqlParameter("@month", SqlDbType.VarChar,50),
                        new SqlParameter("@depart", SqlDbType.VarChar,50),
                        new SqlParameter("@departid", SqlDbType.VarChar,50),
					    new SqlParameter("@empid", SqlDbType.VarChar,50),
                        new SqlParameter("@name", SqlDbType.VarChar,50),
                        new SqlParameter("@gzjb", SqlDbType.VarChar,50),
                        new SqlParameter("@yfje", SqlDbType.Decimal),
                        new SqlParameter("@kqtk",SqlDbType.Decimal),
                        new SqlParameter("@kk", SqlDbType.Decimal),
                        new SqlParameter("@gsk",SqlDbType.Decimal),
                        new SqlParameter("@gjj2", SqlDbType.Decimal),
                        new SqlParameter("@gjj",SqlDbType.Decimal),
                        new SqlParameter("@bxkk",SqlDbType.Decimal),
                        new SqlParameter("@sfje",SqlDbType.Decimal)};
                        parameters[0].Value = model.year;
                        parameters[1].Value = model.month;
                        parameters[2].Value = model.depart;
                        parameters[3].Value = model.departid;
                        parameters[4].Value = model.empid;
                        parameters[5].Value = model.name;
                        parameters[6].Value = model.gzjb;
                        parameters[7].Value = model.yfje;
                        parameters[8].Value = model.kqtk;
                        parameters[9].Value = model.kk;
                        parameters[10].Value = model.gsk;
                        parameters[11].Value = model.gjj2;
                        parameters[12].Value = model.gjj;
                        parameters[13].Value = model.bxkk;
                        parameters[14].Value = model.sfje;

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
        public bool Update(Model.gzmx model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSql.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update t_gzmx set ");
                        strSql.Append("year=@year,");
                        strSql.Append("month=@month,");
                        strSql.Append("name=@name,");
                        strSql.Append("yfje=@yfje,");
                        strSql.Append("kqtk=@kqtk,");
                        strSql.Append("kk=@kk,");
                        strSql.Append("gsk=@gsk,");
                        strSql.Append("gjj2=@gjj2,");
                        strSql.Append("gjj=@gjj,");
                        strSql.Append("bxkk=@bxkk,");
                        strSql.Append("sfje=@sfje");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					    new SqlParameter("@year", SqlDbType.VarChar,50),
					    new SqlParameter("@month", SqlDbType.VarChar,50),
					    new SqlParameter("@empid", SqlDbType.VarChar,50),
                        new SqlParameter("@name", SqlDbType.VarChar,50),
                        new SqlParameter("@yfje", SqlDbType.Decimal),
                        new SqlParameter("@kqtk",SqlDbType.Decimal),
                        new SqlParameter("@kk", SqlDbType.Decimal),
                        new SqlParameter("@gsk",SqlDbType.Decimal),
                        new SqlParameter("@gjj2", SqlDbType.Decimal),
                        new SqlParameter("@gjj",SqlDbType.Decimal),
                        new SqlParameter("@bxkk",SqlDbType.Decimal),
                        new SqlParameter("@sfje",SqlDbType.Decimal),
                        new SqlParameter("@id",SqlDbType.Int,4)};

                        parameters[0].Value = model.year;
                        parameters[1].Value = model.month;
                        parameters[2].Value = model.empid;
                        parameters[3].Value = model.name;
                        parameters[4].Value = model.yfje;
                        parameters[5].Value = model.kqtk;
                        parameters[6].Value = model.kk;
                        parameters[7].Value = model.gsk;
                        parameters[8].Value = model.gjj2;
                        parameters[9].Value = model.gjj;
                        parameters[10].Value = model.bxkk;
                        parameters[11].Value = model.sfje;
                        parameters[12].Value = model.id;
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
            strSql.Append("delete from t_gzmx ");
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
            strSql.Append("delete from t_gzmx ");
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
        public bool Delete(string year,string month)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_gzmx ");
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
        public Model.gzmx GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,year,month,empid,name,yfje,kqtk,kk,gsk,gjj2,gjj,bxkk,sfje from t_gzmx ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.gzmx model = new Model.gzmx();
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
                if (ds.Tables[0].Rows[0]["yfje"] != null && ds.Tables[0].Rows[0]["yfje"].ToString() != "")
                {
                    model.yfje = double.Parse(ds.Tables[0].Rows[0]["yfje"].ToString());
                }
                if (ds.Tables[0].Rows[0]["kqtk"] != null && ds.Tables[0].Rows[0]["kqtk"].ToString() != "")
                {
                    model.kqtk = double.Parse(ds.Tables[0].Rows[0]["kqtk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["kk"] != null && ds.Tables[0].Rows[0]["kk"].ToString() != "")
                {
                    model.kk = double.Parse(ds.Tables[0].Rows[0]["kk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gsk"] != null && ds.Tables[0].Rows[0]["gsk"].ToString() != "")
                {
                    model.gsk = double.Parse(ds.Tables[0].Rows[0]["gsk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gjj2"] != null && ds.Tables[0].Rows[0]["gjj2"].ToString() != "")
                {
                    model.gjj2 = double.Parse(ds.Tables[0].Rows[0]["gjj2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gjj"] != null && ds.Tables[0].Rows[0]["gjj"].ToString() != "")
                {
                    model.gjj = double.Parse(ds.Tables[0].Rows[0]["gjj"].ToString());
                }
                 if (ds.Tables[0].Rows[0]["bxkk"] != null && ds.Tables[0].Rows[0]["bxkk"].ToString() != "")
                {
                    model.bxkk = double.Parse(ds.Tables[0].Rows[0]["bxkk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["sfje"] != null && ds.Tables[0].Rows[0]["sfje"].ToString() != "")
                {
                    model.sfje = double.Parse(ds.Tables[0].Rows[0]["sfje"].ToString());
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
            strSql.Append(" id,year,month,empid,name,yfje,kqtk,kk,gsk,gjj2,gjj,bxkk,sfje ");
            strSql.Append(" FROM t_gzmx ");
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
            strSql.Append(" SELECT id,year,month,empid,name,cast(yfje as float) yfje,cast(kqtk as float) kqtk,cast(kk as float) kk,");
            strSql.Append(" cast(gsk as float) gsk,cast(gjj2 as float) gjj2,cast(gjj as float) gjj,cast(bxkk as float) bxkk,");
            strSql.Append(" cast(sfje as float) sfje");
            strSql.Append(" FROM t_gzmx ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by id,year,month,empid,name,yfje,kqtk,kk,gsk,gjj2,gjj,bxkk,sfje ");

            recordCount = Convert.ToInt32(DbHelperSql.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSql.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}
