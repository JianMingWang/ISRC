/**  版本信息模板在安装目录下，可自行修改。
* vw_Sys_AccountInfo.cs
*
* 功 能： N/A
* 类 名： vw_Sys_AccountInfo
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/16 15:44:08   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ISRC.DAL
{
	/// <summary>
	/// 数据访问类:vw_Sys_AccountInfo
	/// </summary>
	public partial class vw_Sys_AccountInfo
	{
		public vw_Sys_AccountInfo()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ISRC.Model.vw_Sys_AccountInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_Sys_AccountInfo(");
			strSql.Append("ID,Account,AccountPsw,TrueName,State,SortNo,RoleID,DeptID,RoleName,DeptName)");
			strSql.Append(" values (");
			strSql.Append("@ID,@Account,@AccountPsw,@TrueName,@State,@SortNo,@RoleID,@DeptID,@RoleName,@DeptName)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,64),
					new SqlParameter("@Account", SqlDbType.VarChar,32),
					new SqlParameter("@AccountPsw", SqlDbType.VarChar,32),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,32),
					new SqlParameter("@State", SqlDbType.VarChar,2),
					new SqlParameter("@SortNo", SqlDbType.SmallInt,2),
					new SqlParameter("@RoleID", SqlDbType.VarChar,64),
					new SqlParameter("@DeptID", SqlDbType.VarChar,32),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,32),
					new SqlParameter("@DeptName", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.AccountPsw;
			parameters[3].Value = model.TrueName;
			parameters[4].Value = model.State;
			parameters[5].Value = model.SortNo;
			parameters[6].Value = model.RoleID;
			parameters[7].Value = model.DeptID;
			parameters[8].Value = model.RoleName;
			parameters[9].Value = model.DeptName;

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
		public bool Update(ISRC.Model.vw_Sys_AccountInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_Sys_AccountInfo set ");
			strSql.Append("ID=@ID,");
			strSql.Append("Account=@Account,");
			strSql.Append("AccountPsw=@AccountPsw,");
			strSql.Append("TrueName=@TrueName,");
			strSql.Append("State=@State,");
			strSql.Append("SortNo=@SortNo,");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("DeptID=@DeptID,");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("DeptName=@DeptName");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,64),
					new SqlParameter("@Account", SqlDbType.VarChar,32),
					new SqlParameter("@AccountPsw", SqlDbType.VarChar,32),
					new SqlParameter("@TrueName", SqlDbType.NVarChar,32),
					new SqlParameter("@State", SqlDbType.VarChar,2),
					new SqlParameter("@SortNo", SqlDbType.SmallInt,2),
					new SqlParameter("@RoleID", SqlDbType.VarChar,64),
					new SqlParameter("@DeptID", SqlDbType.VarChar,32),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,32),
					new SqlParameter("@DeptName", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.Account;
			parameters[2].Value = model.AccountPsw;
			parameters[3].Value = model.TrueName;
			parameters[4].Value = model.State;
			parameters[5].Value = model.SortNo;
			parameters[6].Value = model.RoleID;
			parameters[7].Value = model.DeptID;
			parameters[8].Value = model.RoleName;
			parameters[9].Value = model.DeptName;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from vw_Sys_AccountInfo ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		public ISRC.Model.vw_Sys_AccountInfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Account,AccountPsw,TrueName,State,SortNo,RoleID,DeptID,RoleName,DeptName from vw_Sys_AccountInfo ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			ISRC.Model.vw_Sys_AccountInfo model=new ISRC.Model.vw_Sys_AccountInfo();
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
		public ISRC.Model.vw_Sys_AccountInfo DataRowToModel(DataRow row)
		{
			ISRC.Model.vw_Sys_AccountInfo model=new ISRC.Model.vw_Sys_AccountInfo();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["Account"]!=null)
				{
					model.Account=row["Account"].ToString();
				}
				if(row["AccountPsw"]!=null)
				{
					model.AccountPsw=row["AccountPsw"].ToString();
				}
				if(row["TrueName"]!=null)
				{
					model.TrueName=row["TrueName"].ToString();
				}
				if(row["State"]!=null)
				{
					model.State=row["State"].ToString();
				}
				if(row["SortNo"]!=null && row["SortNo"].ToString()!="")
				{
					model.SortNo=int.Parse(row["SortNo"].ToString());
				}
				if(row["RoleID"]!=null)
				{
					model.RoleID=row["RoleID"].ToString();
				}
				if(row["DeptID"]!=null)
				{
					model.DeptID=row["DeptID"].ToString();
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["DeptName"]!=null)
				{
					model.DeptName=row["DeptName"].ToString();
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
			strSql.Append("select ID,Account,AccountPsw,TrueName,State,SortNo,RoleID,DeptID,RoleName,DeptName ");
			strSql.Append(" FROM vw_Sys_AccountInfo ");
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
			strSql.Append(" ID,Account,AccountPsw,TrueName,State,SortNo,RoleID,DeptID,RoleName,DeptName ");
			strSql.Append(" FROM vw_Sys_AccountInfo ");
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
			strSql.Append("select count(1) FROM vw_Sys_AccountInfo ");
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
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from vw_Sys_AccountInfo T ");
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
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "vw_Sys_AccountInfo";
			parameters[1].Value = "";
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

