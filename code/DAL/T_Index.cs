using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ISRC.DAL
{
	/// <summary>
	/// 数据访问类:T_Index
	/// </summary>
	public partial class T_Index
	{
		public T_Index()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Index");
			strSql.Append(" where ID=SQL2012ID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ISRC.Model.T_Index model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Index(");
			strSql.Append("ID,Name,Description,OderID,FatherID,Cycle,MultiIndex)");
			strSql.Append(" values (");
            strSql.Append("@SQL2012ID,@SQL2012Name,@SQL2012Description,@SQL2012OderID,@SQL2012FatherID,@Cycle,@MultiIndex)");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Name", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Description", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012OderID", SqlDbType.VarChar,64),
                    new SqlParameter("SQL2012FatherID", SqlDbType.VarChar,64),
                    new SqlParameter("Cycle", SqlDbType.VarChar,64),
                    new SqlParameter("MultiIndex", SqlDbType.VarChar,64)
};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.OderID;
            parameters[4].Value = model.FatherID;
            parameters[5].Value = model.Cycle;
            parameters[6].Value = model.MultiIndex;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
        public bool Update(ISRC.Model.T_Index model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Index set ");
            strSql.Append("Name=@SQL2012Name,");
            strSql.Append("Description=@SQL2012Description,");
            strSql.Append("OderID=@SQL2012OderID,");
            strSql.Append("FatherID=@SQL2012FatherID,");
            strSql.Append("Cycle=@SQL2012Cycle,");
            strSql.Append("MultiIndex=@SQL2012MultiIndex");
            strSql.Append(" where ID=@SQL2012ID ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012Name", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Description", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012OderID", SqlDbType.VarChar,64),
                    new SqlParameter("SQL2012FatherID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64),
                    new SqlParameter("SQL2012Cycle", SqlDbType.Char,1),
                    new SqlParameter("SQL2012MultiIndex", SqlDbType.VarChar,64)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.OderID;
            parameters[3].Value = model.FatherID;
            parameters[4].Value = model.ID;
            parameters[5].Value = model.Cycle;
            parameters[6].Value = model.MultiIndex;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Index ");
			strSql.Append(" where ID=@SQL2012ID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64)			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Index ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public ISRC.Model.T_Index GetModel(string ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,Description,OderID,FatherID,Cycle,MultiIndex from T_Index ");
            strSql.Append(" where ID=@SQL2012ID ");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64)			};
            parameters[0].Value = ID;

            ISRC.Model.T_Index model = new ISRC.Model.T_Index();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ISRC.Model.T_Index DataRowToModel(DataRow row)
        {
            ISRC.Model.T_Index model = new ISRC.Model.T_Index();
            if (row != null)
            {
                if (row["ID"] != null)
                {
                    model.ID = row["ID"].ToString();
                }
                if (row["Name"] != null)
                {
                    model.Name = row["Name"].ToString();
                }
                if (row["Description"] != null)
                {
                    model.Description = row["Description"].ToString();
                }
                if (row["OderID"] != null)
                {
                    model.OderID = row["OderID"].ToString();
                }
                if (row["FatherID"] != null)
                {
                    model.FatherID = row["FatherID"].ToString();
                }
                if (row["Cycle"] != null)
                {
                    model.Cycle = row["Cycle"].ToString();
                }
                if (row["MultiIndex"] != null)
                {
                    model.MultiIndex = row["MultiIndex"].ToString();
                }
            }
            return model;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,Description,OderID,FatherID,Cycle,MultiIndex ");
            strSql.Append(" FROM T_Index ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" ORDER BY CONVERT(int,OderID),CONVERT(int,ID)");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得树装数据列表
        /// </summary>
        public DataSet GetTreeList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ID,Name,FatherID FROM T_Index UNION SELECT ID,Name,FatherID FROM T_IndexCategory ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" ID,Name,Description,OderID,Cycle,MultiIndex ");
            strSql.Append(" FROM T_Index ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_Index ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Index T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012PageSize", SqlDbType.Int),
					new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
					new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
					new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
					new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_Index";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

