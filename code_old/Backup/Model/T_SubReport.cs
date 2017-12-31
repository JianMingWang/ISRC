using System;
namespace ISRC.Model
{
	/// <summary>
	/// T_SubReport:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_SubReport
	{
		public T_SubReport()
		{}
		#region Model
		private string _id;
		private string _reportid;
		private string _indexid;
		private string _indexvalue;
		private string _description;
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
		public string ReportID
		{
			set{ _reportid=value;}
			get{return _reportid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IndexID
		{
			set{ _indexid=value;}
			get{return _indexid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IndexValue
		{
			set{ _indexvalue=value;}
			get{return _indexvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		#endregion Model

	}
}

