using System;
namespace ISRC.Model
{
	/// <summary>
	/// T_Report:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Report
	{
		public T_Report()
		{}
		#region Model
		private string _id;
		private string _cycle;
		private string _year;
		private string _month;
		private string _quarter;
		private string _semiyear;
		private string _deptid;
		private string _userid;
		private string _filldate;
		private string _description;
		private string _status;
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
		public string Cycle
		{
			set{ _cycle=value;}
			get{return _cycle;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Year
		{
			set{ _year=value;}
			get{return _year;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Month
		{
			set{ _month=value;}
			get{return _month;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Quarter
		{
			set{ _quarter=value;}
			get{return _quarter;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SemiYear
		{
			set{ _semiyear=value;}
			get{return _semiyear;}
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
		public string UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FillDate
		{
			set{ _filldate=value;}
			get{return _filldate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

