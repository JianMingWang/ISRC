using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ISRC.DAL
{
	/// <summary>
	/// 数据访问类:T_DeptIndex
	/// </summary>
	public partial class T_DeptIndex
	{
		public T_DeptIndex()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string T_DeptIndex,string IndexID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_DeptIndex");
			strSql.Append(" where T_DeptIndex=SQL2012T_DeptIndex and IndexID=SQL2012IndexID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012T_DeptIndex", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012IndexID", SqlDbType.VarChar,64)			};
			parameters[0].Value = T_DeptIndex;
			parameters[1].Value = IndexID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ISRC.Model.T_DeptIndex model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_DeptIndex(");
			strSql.Append("T_DeptIndex,IndexID)");
			strSql.Append(" values (");
			strSql.Append("SQL2012T_DeptIndex,SQL2012IndexID)");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012T_DeptIndex", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012IndexID", SqlDbType.VarChar,64)};
			parameters[0].Value = model.T_DeptIndex;
			parameters[1].Value = model.IndexID;

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
		public bool Update(ISRC.Model.T_DeptIndex model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_DeptIndex set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("T_DeptIndex=SQL2012T_DeptIndex,");
			strSql.Append("IndexID=SQL2012IndexID");
			strSql.Append(" where T_DeptIndex=SQL2012T_DeptIndex and IndexID=SQL2012IndexID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012T_DeptIndex", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012IndexID", SqlDbType.VarChar,64)};
			parameters[0].Value = model.T_DeptIndex;
			parameters[1].Value = model.IndexID;

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
		public bool Delete(string T_DeptIndex,string IndexID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_DeptIndex ");
			strSql.Append(" where T_DeptIndex=SQL2012T_DeptIndex and IndexID=SQL2012IndexID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012T_DeptIndex", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012IndexID", SqlDbType.VarChar,64)			};
			parameters[0].Value = T_DeptIndex;
			parameters[1].Value = IndexID;

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
		/// 得到一个对象实体
		/// </summary>
		public ISRC.Model.T_DeptIndex GetModel(string T_DeptIndex,string IndexID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 T_DeptIndex,IndexID from T_DeptIndex ");
			strSql.Append(" where T_DeptIndex=SQL2012T_DeptIndex and IndexID=SQL2012IndexID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012T_DeptIndex", SqlDbType.VarChar,64),
					new SqlParameter("SQL2012IndexID", SqlDbType.VarChar,64)			};
			parameters[0].Value = T_DeptIndex;
			parameters[1].Value = IndexID;

			ISRC.Model.T_DeptIndex model=new ISRC.Model.T_DeptIndex();
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
		public ISRC.Model.T_DeptIndex DataRowToModel(DataRow row)
		{
			ISRC.Model.T_DeptIndex model=new ISRC.Model.T_DeptIndex();
			if (row != null)
			{
				if(row["T_DeptIndex"]!=null)
				{
					model.T_DeptIndex=row["T_DeptIndex"].ToString();
				}
				if(row["IndexID"]!=null)
				{
					model.IndexID=row["IndexID"].ToString();
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
			strSql.Append("select T_DeptIndex,IndexID ");
			strSql.Append(" FROM T_DeptIndex ");
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
			strSql.Append(" T_DeptIndex,IndexID ");
			strSql.Append(" FROM T_DeptIndex ");
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
			strSql.Append("select count(1) FROM T_DeptIndex ");
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
				strSql.Append("order by T.IndexID desc");
			}
			strSql.Append(")AS Row, T.*  from T_DeptIndex T ");
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
			parameters[0].Value = "T_DeptIndex";
			parameters[1].Value = "IndexID";
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

