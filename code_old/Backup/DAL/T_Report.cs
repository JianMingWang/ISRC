using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ISRC.DAL
{
	/// <summary>
	/// 数据访问类:T_Report
	/// </summary>
	public partial class T_Report
	{
		public T_Report()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Report");
			strSql.Append(" where ID=SQL2012ID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ISRC.Model.T_Report model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Report(");
			strSql.Append("ID,Cycle,Year,Month,Quarter,SemiYear,DeptID,UserID,FillDate,Description,Status)");
			strSql.Append(" values (");
			strSql.Append("SQL2012ID,SQL2012Cycle,SQL2012Year,SQL2012Month,SQL2012Quarter,SQL2012SemiYear,SQL2012DeptID,SQL2012UserID,SQL2012FillDate,SQL2012Description,SQL2012Status)");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Cycle", SqlDbType.Char,1),
					new SqlParameter("SQL2012Year", SqlDbType.Char,4),
					new SqlParameter("SQL2012Month", SqlDbType.Char,2),
					new SqlParameter("SQL2012Quarter", SqlDbType.Char,1),
					new SqlParameter("SQL2012SemiYear", SqlDbType.Char,6),
					new SqlParameter("SQL2012DeptID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012UserID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012FillDate", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Description", SqlDbType.VarChar,1024),
					new SqlParameter("SQL2012Status", SqlDbType.Char,1)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Cycle;
			parameters[2].Value = model.Year;
			parameters[3].Value = model.Month;
			parameters[4].Value = model.Quarter;
			parameters[5].Value = model.SemiYear;
			parameters[6].Value = model.DeptID;
			parameters[7].Value = model.UserID;
			parameters[8].Value = model.FillDate;
			parameters[9].Value = model.Description;
			parameters[10].Value = model.Status;

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
		public bool Update(ISRC.Model.T_Report model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Report set ");
			strSql.Append("Cycle=SQL2012Cycle,");
			strSql.Append("Year=SQL2012Year,");
			strSql.Append("Month=SQL2012Month,");
			strSql.Append("Quarter=SQL2012Quarter,");
			strSql.Append("SemiYear=SQL2012SemiYear,");
			strSql.Append("DeptID=SQL2012DeptID,");
			strSql.Append("UserID=SQL2012UserID,");
			strSql.Append("FillDate=SQL2012FillDate,");
			strSql.Append("Description=SQL2012Description,");
			strSql.Append("Status=SQL2012Status");
			strSql.Append(" where ID=SQL2012ID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012Cycle", SqlDbType.Char,1),
					new SqlParameter("SQL2012Year", SqlDbType.Char,4),
					new SqlParameter("SQL2012Month", SqlDbType.Char,2),
					new SqlParameter("SQL2012Quarter", SqlDbType.Char,1),
					new SqlParameter("SQL2012SemiYear", SqlDbType.Char,6),
					new SqlParameter("SQL2012DeptID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012UserID", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012FillDate", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012Description", SqlDbType.VarChar,1024),
					new SqlParameter("SQL2012Status", SqlDbType.Char,1),
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64)};
			parameters[0].Value = model.Cycle;
			parameters[1].Value = model.Year;
			parameters[2].Value = model.Month;
			parameters[3].Value = model.Quarter;
			parameters[4].Value = model.SemiYear;
			parameters[5].Value = model.DeptID;
			parameters[6].Value = model.UserID;
			parameters[7].Value = model.FillDate;
			parameters[8].Value = model.Description;
			parameters[9].Value = model.Status;
			parameters[10].Value = model.ID;

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
			strSql.Append("delete from T_Report ");
			strSql.Append(" where ID=SQL2012ID ");
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
			strSql.Append("delete from T_Report ");
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
		public ISRC.Model.T_Report GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Cycle,Year,Month,Quarter,SemiYear,DeptID,UserID,FillDate,Description,Status from T_Report ");
			strSql.Append(" where ID=SQL2012ID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012ID", SqlDbType.VarChar,64)			};
			parameters[0].Value = ID;

			ISRC.Model.T_Report model=new ISRC.Model.T_Report();
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
		public ISRC.Model.T_Report DataRowToModel(DataRow row)
		{
			ISRC.Model.T_Report model=new ISRC.Model.T_Report();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Cycle"]!=null)
				{
					model.Cycle=row["Cycle"].ToString();
				}
				if(row["Year"]!=null)
				{
					model.Year=row["Year"].ToString();
				}
				if(row["Month"]!=null)
				{
					model.Month=row["Month"].ToString();
				}
				if(row["Quarter"]!=null)
				{
					model.Quarter=row["Quarter"].ToString();
				}
				if(row["SemiYear"]!=null)
				{
					model.SemiYear=row["SemiYear"].ToString();
				}
				if(row["DeptID"]!=null)
				{
					model.DeptID=row["DeptID"].ToString();
				}
				if(row["UserID"]!=null)
				{
					model.UserID=row["UserID"].ToString();
				}
				if(row["FillDate"]!=null)
				{
					model.FillDate=row["FillDate"].ToString();
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["Status"]!=null)
				{
					model.Status=row["Status"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Cycle,Year,Month,Quarter,SemiYear,DeptID,UserID,FillDate,Description,Status ");
			strSql.Append(" FROM T_Report ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" ID,Cycle,Year,Month,Quarter,SemiYear,DeptID,UserID,FillDate,Description,Status ");
			strSql.Append(" FROM T_Report ");
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
			strSql.Append("select count(1) FROM T_Report ");
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
			strSql.Append(")AS Row, T.*  from T_Report T ");
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
			parameters[0].Value = "T_Report";
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

