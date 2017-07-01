using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references

namespace ISRC.DAL
{
    public partial class vw_SubReport_Index
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
                sqlString.Append("SELECT * FROM vw_SubReport_Index ");
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


    }
}
