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
    /// 个税计算
    /// </summary>
    public partial class gsjs
    {
        public gsjs()
        { }
        #region  Method
        /// <summary>
        /// 得到最大ID
        /// </summary>
        private int GetMaxId(SqlConnection conn, SqlTransaction trans)
        {
            string strSql = "select top 1 id from r_jshz order by id desc";
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
            strSql.Append("select count(1) from r_jshz");
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
            strSql.Append("select count(1) from r_jshz");
            strSql.Append(" where empid=@empid");
            SqlParameter[] parameters = {
					new SqlParameter("@empid", SqlDbType.VarChar,50)};
            parameters[0].Value = empid;

            return DbHelperSql.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.gsjs model)
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
                        strSql.Append("insert into r_jshz(");
                        strSql.Append("year,month,depart,departid,empid,name,gzjb,yfje,kk,gjj,bxkk,zxkk,jckk,ysgzlj,gslj,bygs)");
                        strSql.Append(" values (");
                        strSql.Append("@year,@month,@depart,@departid,@empid,@name,@gzjb,@yfje,@kk,@gjj,@bxkk,@zxkk,@jckk,@ysgzlj,@gslj,@bygs)");
                        SqlParameter[] parameters = {
					    new SqlParameter("@year", SqlDbType.VarChar,50),
					    new SqlParameter("@month", SqlDbType.VarChar,50),
                        new SqlParameter("@depart", SqlDbType.VarChar,50),
                        new SqlParameter("@departid", SqlDbType.VarChar,50),
					    new SqlParameter("@empid", SqlDbType.VarChar,50),
                        new SqlParameter("@name", SqlDbType.VarChar,50),
                        new SqlParameter("@gzjb", SqlDbType.VarChar,50),
                        new SqlParameter("@yfje", SqlDbType.Decimal),                       
                        new SqlParameter("@kk", SqlDbType.Decimal),                        
                        new SqlParameter("@gjj",SqlDbType.Decimal),
                        new SqlParameter("@bxkk",SqlDbType.Decimal),
                        new SqlParameter("@zxkk",SqlDbType.Decimal),
                        new SqlParameter("@jckk", SqlDbType.Decimal),
                        new SqlParameter("@ysgzlj", SqlDbType.Decimal),
                        new SqlParameter("@gslj", SqlDbType.Decimal),
                        new SqlParameter("@bygs",SqlDbType.Decimal)};

                        parameters[0].Value = model.year;
                        parameters[1].Value = model.month;
                        parameters[2].Value = model.depart;
                        parameters[3].Value = model.departid;
                        parameters[4].Value = model.empid;
                        parameters[5].Value = model.name;
                        parameters[6].Value = model.gzjb;
                        parameters[7].Value = model.yfje;
                        parameters[8].Value = model.kk;
                        parameters[9].Value = model.gjj;
                        parameters[10].Value = model.bxkk;
                        parameters[11].Value = model.zxkk;                        
                        parameters[12].Value = model.jckk;
                        parameters[13].Value = model.ysgzlj;
                        parameters[14].Value = model.gslj;
                        parameters[15].Value = model.bygs;

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
        public bool Update(Model.gsjs model)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSql.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update r_jshz set ");
                        strSql.Append("year=@year,");
                        strSql.Append("month=@month,");
                        strSql.Append("depart=@depart,");
                        strSql.Append("departid=@departid,");
                        strSql.Append("empid=@empid,");
                        strSql.Append("name=@name,");                        
                        strSql.Append("yfje=@yfje,");      
                        strSql.Append("kk=@kk,");                       
                        strSql.Append("gjj=@gjj,");
                        strSql.Append("bxkk=@bxkk,");  
                        strSql.Append("zxkk=@zxkk,"); 
                        strSql.Append("jckk=@jckk,");
                        strSql.Append("ysgzlj=@ysgzlj,");
                        strSql.Append("gslj=@gslj,");
                        strSql.Append("bygs=@bygs");
                        strSql.Append(" where id=@id");
                        SqlParameter[] parameters = {
					    new SqlParameter("@year", SqlDbType.VarChar,50),
					    new SqlParameter("@month", SqlDbType.VarChar,50),
                        new SqlParameter("@depart", SqlDbType.VarChar,50),
                        new SqlParameter("@departid", SqlDbType.VarChar,50),
					    new SqlParameter("@empid", SqlDbType.VarChar,50),
                        new SqlParameter("@name", SqlDbType.VarChar,50),
                        new SqlParameter("@gzjb", SqlDbType.VarChar,50),
                        new SqlParameter("@yfje", SqlDbType.Decimal),                       
                        new SqlParameter("@kk", SqlDbType.Decimal),                        
                        new SqlParameter("@gjj",SqlDbType.Decimal),
                        new SqlParameter("@bxkk",SqlDbType.Decimal),
                        new SqlParameter("@zxkk",SqlDbType.Decimal),
                        new SqlParameter("@jckk", SqlDbType.Decimal),
                        new SqlParameter("@ysgzlj", SqlDbType.Decimal),
                        new SqlParameter("@gslj", SqlDbType.Decimal),
                        new SqlParameter("@bygs",SqlDbType.Decimal),
                        new SqlParameter("@id",SqlDbType.Int,4)};
                        parameters[0].Value = model.year;
                        parameters[1].Value = model.month;
                        parameters[2].Value = model.depart;
                        parameters[3].Value = model.departid;
                        parameters[4].Value = model.empid;
                        parameters[5].Value = model.name;
                        parameters[6].Value = model.gzjb;
                        parameters[7].Value = model.yfje;
                        parameters[9].Value = model.kk;
                        parameters[10].Value = model.gjj;
                        parameters[11].Value = model.bxkk;
                        parameters[12].Value = model.zxkk;
                        parameters[13].Value = model.jckk;
                        parameters[14].Value = model.ysgzlj;
                        parameters[15].Value = model.gslj;
                        parameters[16].Value = model.bygs;
                        parameters[17].Value = model.id;

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
            strSql.Append("delete from r_jshz ");
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
        /// 删除当月数据
        /// </summary>
        /// <param name="empid"></param>
        /// <returns></returns>
        public bool Delete(string year,string month)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from r_jshz ");
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
        /// 获取当月个税汇总
        /// </summary>
        public double taxCount(string year, string month)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(bygs) as bygscount from r_jshz ");
            strSql.Append(" where year=@year and month=@month");
            SqlParameter[] parameters = {
                    new SqlParameter("@year", SqlDbType.VarChar,100),
                    new SqlParameter("@month", SqlDbType.VarChar,100)};
            parameters[0].Value = year;
            parameters[1].Value = month;

            object obj = DbHelperSql.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return double.Parse(obj.ToString());
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.gsjs GetModel(string year, string month,string empid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,year,month,depart,departid,empid,name,gzjb,yfje,kk,gjj,bxkk,zxkk,jckk,ysgzlj,gslj,bygs from r_jshz ");
            strSql.Append(" where year=@year and month=@month and empid=@empid");
            SqlParameter[] parameters = {
					new SqlParameter("@year", SqlDbType.VarChar,100),
                    new SqlParameter("@month", SqlDbType.VarChar,100),
                    new SqlParameter("@empid", SqlDbType.VarChar,100)
			};
            parameters[0].Value = year;
            parameters[1].Value = month;
            parameters[2].Value = empid;


            Model.gsjs model = new Model.gsjs();
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
                if (ds.Tables[0].Rows[0]["depart"] != null && ds.Tables[0].Rows[0]["depart"].ToString() != "")
                {
                    model.depart = ds.Tables[0].Rows[0]["depart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["departid"] != null && ds.Tables[0].Rows[0]["departid"].ToString() != "")
                {
                    model.departid = ds.Tables[0].Rows[0]["departid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["empid"] != null && ds.Tables[0].Rows[0]["empid"].ToString() != "")
                {
                    model.empid = ds.Tables[0].Rows[0]["empid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gzjb"] != null && ds.Tables[0].Rows[0]["gzjb"].ToString() != "")
                {
                    model.gzjb = ds.Tables[0].Rows[0]["gzjb"].ToString();
                }
                if (ds.Tables[0].Rows[0]["yfje"] != null && ds.Tables[0].Rows[0]["yfje"].ToString() != "")
                {
                    model.yfje = double.Parse(ds.Tables[0].Rows[0]["yfje"].ToString());
                }
                if (ds.Tables[0].Rows[0]["kk"] != null && ds.Tables[0].Rows[0]["kk"].ToString() != "")
                {
                    model.kk = double.Parse(ds.Tables[0].Rows[0]["kk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gjj"] != null && ds.Tables[0].Rows[0]["gjj"].ToString() != "")
                {
                    model.gjj = double.Parse(ds.Tables[0].Rows[0]["gjj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bxkk"] != null && ds.Tables[0].Rows[0]["bxkk"].ToString() != "")
                {
                    model.bxkk = double.Parse(ds.Tables[0].Rows[0]["bxkk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["zxkk"] != null && ds.Tables[0].Rows[0]["zxkk"].ToString() != "")
                {
                    model.zxkk = double.Parse(ds.Tables[0].Rows[0]["zxkk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["jckk"] != null && ds.Tables[0].Rows[0]["jckk"].ToString() != "")
                {
                    model.jckk = double.Parse(ds.Tables[0].Rows[0]["jckk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ysgzlj"] != null && ds.Tables[0].Rows[0]["ysgzlj"].ToString() != "")
                {
                    model.ysgzlj = double.Parse(ds.Tables[0].Rows[0]["ysgzlj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gslj"] != null && ds.Tables[0].Rows[0]["gslj"].ToString() != "")
                {
                    model.gslj = double.Parse(ds.Tables[0].Rows[0]["gslj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bygs"] != null && ds.Tables[0].Rows[0]["bygs"].ToString() != "")
                {
                    model.bygs = double.Parse(ds.Tables[0].Rows[0]["bygs"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.gsjs GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,year,month,depart,departid,empid,name,gzjb,yfje,kk,gjj,bxkk,zxkk,jckk,ysgzlj,gslj,bygs from r_jshz ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Model.gsjs model = new Model.gsjs();
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
                if (ds.Tables[0].Rows[0]["depart"] != null && ds.Tables[0].Rows[0]["depart"].ToString() != "")
                {
                    model.depart = ds.Tables[0].Rows[0]["depart"].ToString();
                }
                if (ds.Tables[0].Rows[0]["departid"] != null && ds.Tables[0].Rows[0]["departid"].ToString() != "")
                {
                    model.departid = ds.Tables[0].Rows[0]["departid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["empid"] != null && ds.Tables[0].Rows[0]["empid"].ToString() != "")
                {
                    model.empid = ds.Tables[0].Rows[0]["empid"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["gzjb"] != null && ds.Tables[0].Rows[0]["gzjb"].ToString() != "")
                {
                    model.gzjb = ds.Tables[0].Rows[0]["gzjb"].ToString();
                }
                if (ds.Tables[0].Rows[0]["yfje"] != null && ds.Tables[0].Rows[0]["yfje"].ToString() != "")
                {
                    model.yfje = double.Parse(ds.Tables[0].Rows[0]["yfje"].ToString());
                }               
                if (ds.Tables[0].Rows[0]["kk"] != null && ds.Tables[0].Rows[0]["kk"].ToString() != "")
                {
                    model.kk = double.Parse(ds.Tables[0].Rows[0]["kk"].ToString());
                }               
                if (ds.Tables[0].Rows[0]["gjj"] != null && ds.Tables[0].Rows[0]["gjj"].ToString() != "")
                {
                    model.gjj = double.Parse(ds.Tables[0].Rows[0]["gjj"].ToString());
                }
                 if (ds.Tables[0].Rows[0]["bxkk"] != null && ds.Tables[0].Rows[0]["bxkk"].ToString() != "")
                {
                    model.bxkk = double.Parse(ds.Tables[0].Rows[0]["bxkk"].ToString());
                }  
                if (ds.Tables[0].Rows[0]["zxkk"] != null && ds.Tables[0].Rows[0]["zxkk"].ToString() != "")
                {
                    model.zxkk = double.Parse(ds.Tables[0].Rows[0]["zxkk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["jckk"] != null && ds.Tables[0].Rows[0]["jckk"].ToString() != "")
                {
                    model.jckk = double.Parse(ds.Tables[0].Rows[0]["jckk"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ysgzlj"] != null && ds.Tables[0].Rows[0]["ysgzlj"].ToString() != "")
                {
                    model.ysgzlj = double.Parse(ds.Tables[0].Rows[0]["ysgzlj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["gslj"] != null && ds.Tables[0].Rows[0]["gslj"].ToString() != "")
                {
                    model.gslj = double.Parse(ds.Tables[0].Rows[0]["gslj"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bygs"] != null && ds.Tables[0].Rows[0]["bygs"].ToString() != "")
                {
                    model.bygs = double.Parse(ds.Tables[0].Rows[0]["bygs"].ToString());
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
            strSql.Append(" (year+'/'+month) as 年月,depart  as 部门,departid as 部门代号,name as 姓名,");//,gzjb as 工资级别
            strSql.Append(" empid as 工号,cast(yfje as float) 应发金额,cast(kk as float) 扣款,cast(gjj as float) 公积金,cast(bxkk as float) 保险扣款, ");
            strSql.Append(" cast(zxkk as float) 专项扣除总额,cast(jckk as int) 基础扣款,cast(ysgzlj as float) 本年应税工资累计,cast(gslj as float) 本年个税累计,cast(bygs as float) 本月个税 ");
            strSql.Append(" FROM r_jshz ");
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
            strSql.Append(" SELECT c.id,c.year,c.month,c.empid,c.name,c.yfje,c.kk,c.gjj,c.bxkk,c.zxkc,c.jckk ");
            strSql.Append(" ,(c.kk+c.gjj+c.bxkk+c.zxkc+c.jckk) as total ");
            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT A.id,a.year,a.month, a.empid,a.name,a.yfje,(a.kqtk+a.kk+a.gsk) as kk,(a.gjj2+a.gjj) as gjj,a.bxkk,");
            strSql.Append(" ISNULL((b.znjy+b.jxjy+b.dbyl+b.zfdk+b.zfzj+b.sylr),0) as zxkc,5000 as jckk");
            strSql.Append("  FROM t_gzmx a ");
            strSql.Append(" LEFT JOIN t_zxkc b ");
            strSql.Append(" on a.empid=b.empid and a.year=b.year and a.month=b.month ");          
            //strSql.Append(" where a.year='2019' and a.month='2' ");
            strSql.Append(" group by A.id, a.year,a.month, a.empid,a.name,a.yfje,a.kqtk,a.kk,a.gsk,a.gjj2,a.gjj,a.bxkk, ");
            strSql.Append(" b.znjy,b.jxjy,b.dbyl,b.zfdk,b.zfzj,b.sylr ");
            strSql.Append(" ) c ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by c.id,c.year,c.month,c.empid,c.name,c.yfje,c.kk,c.gjj,c.bxkk,c.zxkc,c.jckk ");

            /* strSql.Append(" SELECT id,year,month,empid,name,yfje,kqtk,kk,gsk,gjj2,gjj,bxkk,sfje");
            strSql.Append(" FROM r_jshz ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by id,year,month,empid,name,yfje,kqtk,kk,gsk,gjj2,gjj,bxkk,sfje ");*/

            recordCount = Convert.ToInt32(DbHelperSql.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSql.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList1(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT id,year,month,depart,departid,empid,name,gzjb,");
            strSql.Append(" cast(yfje as float) yfje,cast(kk as float) kk, cast(gjj as float) gjj,cast(bxkk as float) bxkk,");
            strSql.Append(" cast(zxkk as float) zxkk,cast(jckk as INT) jckk ,cast(ysgzlj as float) ysgzlj,cast(gslj as float) gslj,");
            strSql.Append(" cast(bygs as float) bygs,cast((kk+gjj+bxkk+zxkk+jckk) as float) total ");
            strSql.Append(" FROM r_jshz ");
            if (strWhere != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" group by id,year,month,depart,departid,empid,name,gzjb,yfje,kk,gjj,bxkk,zxkk,jckk,ysgzlj,gslj,bygs ");

            recordCount = Convert.ToInt32(DbHelperSql.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSql.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method

    }
}
