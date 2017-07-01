using System;
using System.Collections.Generic;
using System.Text;
using ISRC.DAL;
using System.Data;

namespace ISRC.BLL
{
    public partial class vw_Dept_Index
    {
        private readonly ISRC.DAL.vw_Dept_Index dal = new ISRC.DAL.vw_Dept_Index();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
