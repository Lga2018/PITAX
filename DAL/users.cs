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
    /// 用户管理
    /// </summary>
    public partial class users
    {
        public users()
        { }
        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from t_users order by id desc";
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
            strSql.Append("select count(1) from t_users");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id",SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_users");
            strSql.Append(" where username=@username");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,50)};
            parameters[0].Value = username;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.users model)
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
                        strSql.Append("insert into t_users(");
                        strSql.Append("name,departid,username,password,role,addtime,note)");
                        strSql.Append(" values (");
                        strSql.Append("@name,@departid,@username,@password,@role,@addtime,@note)");
                        SqlParameter[] parameters = {
					    new SqlParameter("@name", SqlDbType.VarChar,50),
					    new SqlParameter("@departid", SqlDbType.VarChar,50),
                        new SqlParameter("@username", SqlDbType.VarChar,50),
                        new SqlParameter("@password", SqlDbType.VarChar,50),
					    new SqlParameter("@role", SqlDbType.Int),
                        new SqlParameter("@addtime", SqlDbType.VarChar,50),
                        new SqlParameter("@note", SqlDbType.VarChar,50)};
                        parameters[0].Value = model.name;
                        parameters[1].Value = model.departid;
                        parameters[2].Value = model.username;
                        parameters[3].Value = model.password;
                        parameters[4].Value = model.role;
                        parameters[5].Value = model.addtime;
                        parameters[6].Value = model.note;

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
        public bool Update(Model.users model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSql.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update t_users set ");
                        strSql.Append("name=@name,");
                        strSql.Append("departid=@departid,");
                        strSql.Append("username=@username,");
                        strSql.Append("password=@password,");
                        strSql.Append("role=@role,");
                        strSql.Append("addtime=@addtime,");
                        strSql.Append("note=@note");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					    new SqlParameter("@name", SqlDbType.VarChar,50),
					    new SqlParameter("@departid", SqlDbType.VarChar,50),
                        new SqlParameter("@username", SqlDbType.VarChar,50),
                        new SqlParameter("@password", SqlDbType.VarChar,50),
					    new SqlParameter("@role", SqlDbType.Int),
                        new SqlParameter("@addtime", SqlDbType.VarChar,50),
                        new SqlParameter("@note", SqlDbType.VarChar,50),
                        new SqlParameter("@id",SqlDbType.Int,4)};
                        parameters[0].Value = model.name;
                        parameters[1].Value = model.departid;
                        parameters[2].Value = model.username;
                        parameters[3].Value = model.password;
                        parameters[4].Value = model.role;
                        parameters[5].Value = model.addtime;
                        parameters[6].Value = model.note;
                        parameters[7].Value = model.id;
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
            strSql.Append("delete from t_users ");
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
        public bool Delete(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_users ");
            strSql.Append(" where username=@username");
            SqlParameter[] parameters = {
                    new SqlParameter("@username", SqlDbType.VarChar,100)};
            parameters[0].Value = username;

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
        public Model.users GetModel(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,departid,username,password,role,addtime,note from t_users ");
            strSql.Append(" where username=@username");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.VarChar,50)
			};
            parameters[0].Value = username;

            Model.users model = new Model.users();
            DataSet ds = DbHelperSql.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["departid"] != null && ds.Tables[0].Rows[0]["departid"].ToString() != "")
                {
                    model.departid = ds.Tables[0].Rows[0]["departid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["username"] != null && ds.Tables[0].Rows[0]["username"].ToString() != "")
                {
                    model.username = ds.Tables[0].Rows[0]["username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["password"] != null && ds.Tables[0].Rows[0]["password"].ToString() != "")
                {
                    model.password = ds.Tables[0].Rows[0]["password"].ToString();
                }
                if (ds.Tables[0].Rows[0]["role"] != null && ds.Tables[0].Rows[0]["role"].ToString() != "")
                {
                    model.role = int.Parse(ds.Tables[0].Rows[0]["role"].ToString());
                }
                if (ds.Tables[0].Rows[0]["addtime"] != null && ds.Tables[0].Rows[0]["addtime"].ToString() != "")
                {
                    model.addtime = ds.Tables[0].Rows[0]["addtime"].ToString();
                }
                if (ds.Tables[0].Rows[0]["note"] != null && ds.Tables[0].Rows[0]["note"].ToString() != "")
                {
                    model.note = ds.Tables[0].Rows[0]["note"].ToString();
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
            strSql.Append(" id,name,departid,username,password,role,addtime,note ");
            strSql.Append(" FROM t_users ");
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
            strSql.Append(" SELECT id,name,departid,username,password,role,addtime,note ");
            strSql.Append(" FROM t_users ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by id,name,departid,username,password,role,addtime,note ");

            recordCount = Convert.ToInt32(DbHelperSql.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSql.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}
