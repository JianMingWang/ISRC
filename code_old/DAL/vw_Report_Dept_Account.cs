using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace ISRC.DAL
{
    public partial class vw_Report_Dept_Account
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            string connString = PubConstant.ConnectionString;
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                StringBuilder sqlString = new StringBuilder();
                sqlString.Append("SELECT * FROM vw_Report_Dept_Account ");
                if (strWhere.ToString().Trim() != "")
                {
                    sqlString.Append(" where " + strWhere);
                }

                using (SqlDataAdapter da = new SqlDataAdapter(sqlString.ToString(), conn))
                {
                    da.Fill(ds);
                }
            }
            return ds;
        }

        public DataSet SearchReportList(string Cycle, string Start_Year, string Star_Period, string End_Year, string End_Period, string Status)
        {
            SqlParameter[] parameters = {
                          new SqlParameter("@Cycle", SqlDbType.NVarChar,64),
                          new SqlParameter("@Start_Year", SqlDbType.NVarChar,32),
                         new SqlParameter("@Start_Period", SqlDbType.NVarChar,32),
                         new SqlParameter("@End_Year", SqlDbType.NVarChar,32),
                         new SqlParameter("@End_Period", SqlDbType.NVarChar,32),
                         new SqlParameter("@Status", SqlDbType.NVarChar,32)
                          };
            parameters[0].Value = Cycle;
            parameters[1].Value = Start_Year;
            parameters[2].Value = Star_Period;
            parameters[3].Value = End_Year;
            parameters[4].Value = End_Period;
            parameters[5].Value = Status;
            return DbHelperSQL.RunProcedure("sp_Search_ReportList", parameters, "Report");
        }
    }
}
