using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WcfTestApp.dal
{
    public class StoredProcMethods
    {
        /// <summary>
        /// Execute a stored procedure
        /// </summary>
        /// <param name="sp"></param>
        /// <returns></returns>
        public static DataSet ExecStoredProc(string sp, string connection)
        {
            String sql = sp;
            DataSet ds = Helpers.GetDataSetFromStoredProcedure("EXEC " + sql, connection);
            return ds;
        }       
    }
}