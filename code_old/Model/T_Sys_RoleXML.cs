/**  版本信息模板在安装目录下，可自行修改。
* T_Sys_RoleXML.cs
*
* 功 能： N/A
* 类 名： T_Sys_RoleXML
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/8 15:26:43   N/A    初版
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
	/// T_Sys_RoleXML:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Sys_RoleXML
	{
		public T_Sys_RoleXML()
		{}
		#region Model
		private string _id;
		private string _roleid;
		private string _rolexml;
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
		public string RoleID
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RoleXml
		{
			set{ _rolexml=value;}
			get{return _rolexml;}
		}
		#endregion Model

	}
}

