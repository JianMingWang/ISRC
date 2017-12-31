/**  版本信息模板在安装目录下，可自行修改。
* T_Sys_Menu.cs
*
* 功 能： N/A
* 类 名： T_Sys_Menu
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/8 15:26:42   N/A    初版
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
	/// T_Sys_Menu:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Sys_Menu
	{
		public T_Sys_Menu()
		{}
		#region Model
		private string _id;
		private string _menuname;
		private string _parentid;
		private string _menuurl;
		private string _imageurl;
		private int? _sortno;
		private string _state;
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
		public string MenuName
		{
			set{ _menuname=value;}
			get{return _menuname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MenuUrl
		{
			set{ _menuurl=value;}
			get{return _menuurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImageUrl
		{
			set{ _imageurl=value;}
			get{return _imageurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SortNo
		{
			set{ _sortno=value;}
			get{return _sortno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string State
		{
			set{ _state=value;}
			get{return _state;}
		}
		#endregion Model

	}
}

