using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System;

namespace ISRC.DAL
{
    public class Common
    {
        public Common()
        { }

        public DataSet getDataPage(string tableName, string fields, string sqlWhere, string order, int pageSize, int pageIndex, out long totalRecord)
        {
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@tableName", SqlDbType.NVarChar,64), 
			 			 new SqlParameter("@fields", SqlDbType.NVarChar,1024), 
			 			 new SqlParameter("@sqlWhere", SqlDbType.NVarChar,1024), 
			 			 new SqlParameter("@order", SqlDbType.NVarChar,1024), 
			 			 new SqlParameter("@pageSize", SqlDbType.Int), 
			 			 new SqlParameter("@pageIndex", SqlDbType.Int), 
			 			 new SqlParameter("@totalRecord", SqlDbType.BigInt) 
			 			 };
            parameters[0].Value = tableName;
            parameters[1].Value = fields;
            parameters[2].Value = sqlWhere;
            parameters[3].Value = order;
            parameters[4].Value = pageSize;
            parameters[5].Value = pageIndex;
            parameters[6].Direction = ParameterDirection.Output;
            DataSet ds = DbHelperSQL.RunProcedure("proc_dataPage_Common", parameters, tableName);
            totalRecord = int.Parse(parameters[6].Value.ToString());
            return ds;
        }

        public bool generateCalendar(DateTime start)
        {
            int rowsAffected;
            SqlParameter[] parameters = {			 
			 			 new SqlParameter("@start", SqlDbType.DateTime) 
			 			 };
            parameters[0].Value = start;
            DbHelperSQL.RunProcedure("proc_generateCalendar", parameters, out rowsAffected);
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
