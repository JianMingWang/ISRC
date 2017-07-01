using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ISRC.DAL
{
	/// <summary>
	/// 数据访问类:T_Dept
	/// </summary>
	public partial class T_Dept
	{
		public T_Dept()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Dept");
			strSql.Append(" where ID=SQL2012ID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(ISRC.Model.T_Dept model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Dept(");
            strSql.Append("ID,Name,Quality,RegionID,Contactor,Tel,OderID)");
            strSql.Append(" values (");
            strSql.Append("@SQL2012ID,@SQL2012Name,@SQL2012Quality,@SQL2012RegionID,@SQL2012Contactor,@SQL2012Tel,@SQL2012OderID)");
            SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Name", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Quality", SqlDbType.Char,1),
					new SqlParameter("SQL2012RegionID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Contactor", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Tel", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012OderID", SqlDbType.VarChar,64)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Quality;
            parameters[3].Value = model.RegionID;
            parameters[4].Value = model.Contactor;
            parameters[5].Value = model.Tel;
            parameters[6].Value = model.OderID;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(ISRC.Model.T_Dept model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Dept set ");
			strSql.Append("Name=@SQL2012Name,");
			strSql.Append("Quality=@SQL2012Quality,");
			strSql.Append("RegionID=@SQL2012RegionID,");
			strSql.Append("Contactor=@SQL2012Contactor,");
			strSql.Append("Tel=@SQL2012Tel,");
			strSql.Append("OderID=@SQL2012OderID");
			strSql.Append(" where ID=@SQL2012ID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Name", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Quality", SqlDbType.Char,1),
					new SqlParameter("SQL2012RegionID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Contactor", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Tel", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012OderID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Quality;
			parameters[2].Value = model.RegionID;
			parameters[3].Value = model.Contactor;
			parameters[4].Value = model.Tel;
			parameters[5].Value = model.OderID;
			parameters[6].Value = model.ID;

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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Dept ");
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
			strSql.Append("delete from T_Dept ");
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
		public ISRC.Model.T_Dept GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Name,Quality,RegionID,Contactor,Tel,OderID from T_Dept ");
			strSql.Append(" where ID=@SQL2012ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SQL2012ID", SqlDbType.VarChar,64)			};
			parameters[0].Value = ID;

			ISRC.Model.T_Dept model=new ISRC.Model.T_Dept();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public ISRC.Model.T_Dept DataRowToModel(DataRow row)
		{
			ISRC.Model.T_Dept model=new ISRC.Model.T_Dept();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Quality"]!=null)
				{
					model.Quality=row["Quality"].ToString();
				}
				if(row["RegionID"]!=null)
				{
					model.RegionID=row["RegionID"].ToString();
				}
				if(row["Contactor"]!=null)
				{
					model.Contactor=row["Contactor"].ToString();
				}
				if(row["Tel"]!=null)
				{
					model.Tel=row["Tel"].ToString();
				}
				if(row["OderID"]!=null)
				{
					model.OderID=row["OderID"].ToString();
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
            strSql.Append("select T_Dept.ID ID,T_Dept.Name Name,Quality,Contactor,Tel,OderID,T_Region.Name RegionName,T_Region.ID RegionID");
            strSql.Append(" FROM T_Dept LEFT JOIN T_Region on T_Dept.RegionID= T_Region.ID ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Name,Quality,RegionID,Contactor,Tel,OderID ");
			strSql.Append(" FROM T_Dept ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append("select count(1) FROM T_Dept ");
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
			strSql.Append(")AS Row, T.*  from T_Dept T ");
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
			parameters[0].Value = "T_Dept";
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

