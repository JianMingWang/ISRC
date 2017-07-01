/**  版本信息模板在安装目录下，可自行修改。
* vw_Sys_RoleMenuUrl.cs
*
* 功 能： N/A
* 类 名： vw_Sys_RoleMenuUrl
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/18 17:59:27   N/A    初版
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
	/// 数据访问类:vw_Sys_RoleMenuUrl
	/// </summary>
	public partial class vw_Sys_RoleMenuUrl
	{
		public vw_Sys_RoleMenuUrl()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ISRC.Model.vw_Sys_RoleMenuUrl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into vw_Sys_RoleMenuUrl(");
			strSql.Append("ID,RoleName,RoleID,MenuName,MenuID,MenuUrl)");
			strSql.Append(" values (");
			strSql.Append("@ID,@RoleName,@RoleID,@MenuName,@MenuID,@MenuUrl)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,64),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,32),
					new SqlParameter("@RoleID", SqlDbType.VarChar,64),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuID", SqlDbType.VarChar,64),
					new SqlParameter("@MenuUrl", SqlDbType.VarChar,128)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.RoleName;
			parameters[2].Value = model.RoleID;
			parameters[3].Value = model.MenuName;
			parameters[4].Value = model.MenuID;
			parameters[5].Value = model.MenuUrl;

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
		public bool Update(ISRC.Model.vw_Sys_RoleMenuUrl model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update vw_Sys_RoleMenuUrl set ");
			strSql.Append("ID=@ID,");
			strSql.Append("RoleName=@RoleName,");
			strSql.Append("RoleID=@RoleID,");
			strSql.Append("MenuName=@MenuName,");
			strSql.Append("MenuID=@MenuID,");
			strSql.Append("MenuUrl=@MenuUrl");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.VarChar,64),
					new SqlParameter("@RoleName", SqlDbType.NVarChar,32),
					new SqlParameter("@RoleID", SqlDbType.VarChar,64),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,64),
					new SqlParameter("@MenuID", SqlDbType.VarChar,64),
					new SqlParameter("@MenuUrl", SqlDbType.VarChar,128)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.RoleName;
			parameters[2].Value = model.RoleID;
			parameters[3].Value = model.MenuName;
			parameters[4].Value = model.MenuID;
			parameters[5].Value = model.MenuUrl;

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
			strSql.Append("delete from vw_Sys_RoleMenuUrl ");
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
		public ISRC.Model.vw_Sys_RoleMenuUrl GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,RoleName,RoleID,MenuName,MenuID,MenuUrl from vw_Sys_RoleMenuUrl ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			ISRC.Model.vw_Sys_RoleMenuUrl model=new ISRC.Model.vw_Sys_RoleMenuUrl();
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
		public ISRC.Model.vw_Sys_RoleMenuUrl DataRowToModel(DataRow row)
		{
			ISRC.Model.vw_Sys_RoleMenuUrl model=new ISRC.Model.vw_Sys_RoleMenuUrl();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["RoleName"]!=null)
				{
					model.RoleName=row["RoleName"].ToString();
				}
				if(row["RoleID"]!=null)
				{
					model.RoleID=row["RoleID"].ToString();
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["MenuID"]!=null)
				{
					model.MenuID=row["MenuID"].ToString();
				}
				if(row["MenuUrl"]!=null)
				{
					model.MenuUrl=row["MenuUrl"].ToString();
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
			strSql.Append("select ID,RoleName,RoleID,MenuName,MenuID,MenuUrl ");
			strSql.Append(" FROM vw_Sys_RoleMenuUrl ");
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
			strSql.Append(" ID,RoleName,RoleID,MenuName,MenuID,MenuUrl ");
			strSql.Append(" FROM vw_Sys_RoleMenuUrl ");
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
			strSql.Append("select count(1) FROM vw_Sys_RoleMenuUrl ");
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
			strSql.Append(")AS Row, T.*  from vw_Sys_RoleMenuUrl T ");
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
			parameters[0].Value = "vw_Sys_RoleMenuUrl";
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

