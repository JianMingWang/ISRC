using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ISRC.Model;
namespace ISRC.BLL
{
	/// <summary>
	/// T_DeptIndex
	/// </summary>
	public partial class T_DeptIndex
	{
		private readonly ISRC.DAL.T_DeptIndex dal=new ISRC.DAL.T_DeptIndex();
		public T_DeptIndex()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string T_DeptIndex,string IndexID)
		{
			return dal.Exists(T_DeptIndex,IndexID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ISRC.Model.T_DeptIndex model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ISRC.Model.T_DeptIndex model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string T_DeptIndex,string IndexID)
		{
			
			return dal.Delete(T_DeptIndex,IndexID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ISRC.Model.T_DeptIndex GetModel(string T_DeptIndex,string IndexID)
		{
			
			return dal.GetModel(T_DeptIndex,IndexID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ISRC.Model.T_DeptIndex GetModelByCache(string T_DeptIndex,string IndexID)
		{
			
			string CacheKey = "T_DeptIndexModel-" + T_DeptIndex+IndexID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(T_DeptIndex,IndexID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ISRC.Model.T_DeptIndex)objModel;
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
		public List<ISRC.Model.T_DeptIndex> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ISRC.Model.T_DeptIndex> DataTableToList(DataTable dt)
		{
			List<ISRC.Model.T_DeptIndex> modelList = new List<ISRC.Model.T_DeptIndex>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ISRC.Model.T_DeptIndex model;
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

