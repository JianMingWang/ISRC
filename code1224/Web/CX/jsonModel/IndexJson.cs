using System.Collections;
using System.Collections.Generic;

namespace ISRC.Web.CX.jsonModel
{
    /// <summary>
    /// 单指标、多指标指定时间段数据汇总
    /// </summary>
    public class IndexJson
    {
        /// <summary>
        /// 指标的名称集合，多个指标的名称
        /// </summary>
        private ArrayList indexNameArr;

        /// <summary>
        /// 多个指标的键值数据
        /// 键为时间，值为数组，数组存放多个指标的值
        /// </summary>
        private Dictionary<string, ArrayList> data;

        public ArrayList IndexNameArr
        {
            get { return indexNameArr; }
            set { indexNameArr = value; }
        }

        public Dictionary<string, ArrayList> Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}