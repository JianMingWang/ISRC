using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace ISRC.DAL
{
    public partial class vw_CX_ReportDetails
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
                sqlString.Append("SELECT * FROM vw_CX_ReportDetails ");
                sqlString.Append(" where " + strWhere);
                using (SqlDataAdapter da = new SqlDataAdapter(sqlString.ToString(), conn))
                {
                    da.Fill(ds);
                }
            }
            return ds;
        }
    }
}
