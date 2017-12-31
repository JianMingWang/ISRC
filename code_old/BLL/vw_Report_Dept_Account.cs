using System;
using System.Collections.Generic;
using System.Text;
using ISRC.DAL;
using System.Data;

namespace ISRC.BLL
{
    public partial class vw_Report_Dept_Account
    {
        private readonly ISRC.DAL.vw_Report_Dept_Account dal = new DAL.vw_Report_Dept_Account();
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public DataSet SearchReportList(string Cycle, string Start_Year, string Star_Period, string End_Year, string End_Period, string Status)
        {
            return dal.SearchReportList(Cycle, Start_Year, Star_Period, End_Year, End_Period, Status);
        }
    }
}
