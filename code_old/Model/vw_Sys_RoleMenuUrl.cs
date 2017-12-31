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
namespace ISRC.Model
{
	/// <summary>
	/// vw_Sys_RoleMenuUrl:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class vw_Sys_RoleMenuUrl
	{
		public vw_Sys_RoleMenuUrl()
		{}
		#region Model
		private string _id;
		private string _rolename;
		private string _roleid;
		private string _menuname;
		private string _menuid;
		private string _menuurl;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleName
		{
			set{ _rolename=value;}
			get{return _rolename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuID
		{
			set{ _menuid=value;}
			get{return _menuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuUrl
		{
			set{ _menuurl=value;}
			get{return _menuurl;}
		}
		#endregion Model

	}
}

