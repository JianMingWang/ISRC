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
using System.Collections.Generic;
using Maticsoft.Common;
using ISRC.Model;

namespace ISRC.BLL
{
	/// <summary>
	/// vw_Sys_RoleMenuUrl
	/// </summary>
	public partial class vw_Sys_RoleMenuUrl
	{
		private readonly ISRC.DAL.vw_Sys_RoleMenuUrl dal=new ISRC.DAL.vw_Sys_RoleMenuUrl();
		public vw_Sys_RoleMenuUrl()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(ISRC.Model.vw_Sys_RoleMenuUrl model)
        {
            return dal.Add(model);
        }

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ISRC.Model.vw_Sys_RoleMenuUrl model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ISRC.Model.vw_Sys_RoleMenuUrl GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ISRC.Model.vw_Sys_RoleMenuUrl GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "vw_Sys_RoleMenuUrlModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ISRC.Model.vw_Sys_RoleMenuUrl)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ISRC.Model.vw_Sys_RoleMenuUrl> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ISRC.Model.vw_Sys_RoleMenuUrl> DataTableToList(DataTable dt)
		{
			List<ISRC.Model.vw_Sys_RoleMenuUrl> modelList = new List<ISRC.Model.vw_Sys_RoleMenuUrl>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ISRC.Model.vw_Sys_RoleMenuUrl model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

