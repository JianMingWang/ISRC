/**  版本信息模板在安装目录下，可自行修改。
* T_Sys_Account.cs
*
* 功 能： N/A
* 类 名： T_Sys_Account
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/11/8 15:26:41   N/A    初版
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
	/// T_Sys_Account:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Sys_Account
	{
		public T_Sys_Account()
		{}
		#region Model
		private string _id;
		private string _account;
		private string _accountpsw;
		private string _truename;
		private string _deptid;
		private string _roleid;
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
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountPsw
		{
			set{ _accountpsw=value;}
			get{return _accountpsw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeptID
		{
			set{ _deptid=value;}
			get{return _deptid;}
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

