using System;
namespace ISRC.Model
{
	/// <summary>
	/// T_DeptIndex:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_DeptIndex
	{
		public T_DeptIndex()
		{}
		#region Model
		private string _t_deptindex;
		private string _indexid;
		/// <summary>
		/// 
		/// </summary>
		public string T_DeptIndex
		{
			set{ _t_deptindex=value;}
			get{return _t_deptindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IndexID
		{
			set{ _indexid=value;}
			get{return _indexid;}
		}
		#endregion Model

	}
}

