using System;
namespace ISRC.Model
{
    /// <summary>
    /// T_Index:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Index
    {
        public T_Index()
        { }
        #region Model

        private string _id;
        private string _name;
        private string _description;
        private string _oderid;
        private string _fatherid;
        private string _Cycle;
        private string _MultiIndex;
        /// <summary>
        /// 
        /// </summary>
        public string ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OderID
        {
            set { _oderid = value; }
            get { return _oderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FatherID
        {
            set { _fatherid = value; }
            get { return _fatherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cycle
        {
            set { _Cycle = value; }
            get { return _Cycle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MultiIndex
        {
            set { _MultiIndex = value; }
            get { return _MultiIndex; }
        }

        #endregion Model

    }
}

