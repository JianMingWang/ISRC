using System;
using System.Collections.Generic;
using System.Text;
using ISRC.DAL;
using System.Data;

namespace ISRC.BLL
{
    public partial class vw_CX_ReportDetails
    {
        private readonly ISRC.DAL.vw_CX_ReportDetails dal = new ISRC.DAL.vw_CX_ReportDetails();

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
    }
}
