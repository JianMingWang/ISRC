/**  版本信息模板在安装目录下，可自行修改。
* tb_SYS_Parameter.cs
*
* 功 能： N/A
* 类 名： tb_SYS_Parameter
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/6/5 23:05:25   N/A    初版
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
	/// 数据访问类:tb_SYS_Parameter
	/// </summary>
	public partial class tb_SYS_Parameter
	{
		public tb_SYS_Parameter()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_SYS_Parameter");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ISRC.Model.tb_SYS_Parameter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_SYS_Parameter(");
			strSql.Append("ID,ParameterNO,Value,Status)");
			strSql.Append(" values (");
			strSql.Append("@ID,@ParameterNO,@Value,@Status)");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64),
					new SqlParameter("@ParameterNO", SqlDbType.NVarChar,32),
					new SqlParameter("@Value", SqlDbType.NVarChar,64),
					new SqlParameter("@Status", SqlDbType.NVarChar,1)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.ParameterNO;
			parameters[2].Value = model.Value;
			parameters[3].Value = model.Status;

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
		public bool Update(ISRC.Model.tb_SYS_Parameter model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_SYS_Parameter set ");
			strSql.Append("ParameterNO=@ParameterNO,");
			strSql.Append("Value=@Value,");
			strSql.Append("Status=@Status");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ParameterNO", SqlDbType.NVarChar,32),
					new SqlParameter("@Value", SqlDbType.NVarChar,64),
					new SqlParameter("@Status", SqlDbType.NVarChar,1),
					new SqlParameter("@ID", SqlDbType.NVarChar,64)};
			parameters[0].Value = model.ParameterNO;
			parameters[1].Value = model.Value;
			parameters[2].Value = model.Status;
			parameters[3].Value = model.ID;

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
			strSql.Append("delete from tb_SYS_Parameter ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
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
			strSql.Append("delete from tb_SYS_Parameter ");
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
		public ISRC.Model.tb_SYS_Parameter GetModel(string ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,ParameterNO,Value,Status from tb_SYS_Parameter ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,64)			};
			parameters[0].Value = ID;

			ISRC.Model.tb_SYS_Parameter model=new ISRC.Model.tb_SYS_Parameter();
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
		public ISRC.Model.tb_SYS_Parameter DataRowToModel(DataRow row)
		{
			ISRC.Model.tb_SYS_Parameter model=new ISRC.Model.tb_SYS_Parameter();
			if (row != null)
			{
				if(row["ID"]!=null)
				{
					model.ID=row["ID"].ToString();
				}
				if(row["ParameterNO"]!=null)
				{
					model.ParameterNO=row["ParameterNO"].ToString();
				}
				if(row["Value"]!=null)
				{
					model.Value=row["Value"].ToString();
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
			strSql.Append("select ID,ParameterNO,Value,Status ");
			strSql.Append(" FROM tb_SYS_Parameter ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

