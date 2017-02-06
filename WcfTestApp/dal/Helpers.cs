using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WcfTestApp.dal
{
    public class Helpers
    {
        /// <summary>
        /// Helper class to execute a stored procedure and return the results in a DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataSet GetDataSetFromStoredProcedure(string sql, string connectionString)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            adapter.SelectCommand.CommandTimeout = 180; // 3 minutes            

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            connection.Close();
            return ds;
        }
    }
}