using System;
namespace ISRC.Model
{
	/// <summary>
	/// T_Dept:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class T_Dept
	{
		public T_Dept()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _quality;
		private string _regionid;
		private string _contactor;
		private string _tel;
		private string _oderid;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Quality
		{
			set{ _quality=value;}
			get{return _quality;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string RegionID
		{
			set{ _regionid=value;}
			get{return _regionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contactor
		{
			set{ _contactor=value;}
			get{return _contactor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OderID
		{
			set{ _oderid=value;}
			get{return _oderid;}
		}
		#endregion Model

	}
}

