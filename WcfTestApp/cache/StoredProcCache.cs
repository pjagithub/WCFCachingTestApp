using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Caching;
using System.IO;
using WcfTestApp.dal;
using System.Data;

// http://msdn.microsoft.com/en-us/library/ff477235.aspx#Y2900

namespace WcfTestApp.cache
{
    public class StoredProcCache
    {
        /// <summary>
        /// This cache stores the results of a stored procedure. The result is returned as a DataSet type
        /// </summary>
        /// <param name="cacheKey">Cache name. Unique per stored procedure</param>
        /// <param name="cacheExpireMinutes">Cache timeout in minutes</param>
        /// <param name="cacheExpireSeconds">Cache timeout in seconds</param>
        /// <param name="sql">Stored procedure name. Example: [schema].[storedprocname]</param>
        /// <returns></returns>
        public static DataSet Access(string cacheKey, double cacheExpireMinutes, double cacheExpireSeconds, string sql, string connection)
        {
            ObjectCache cache = MemoryCache.Default;
            DataSet cacheContents = cache[cacheKey] as DataSet;

            // check the cache, if null then make a database call and populate
            if (cacheContents == null)
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                double expireSeconds = cacheExpireMinutes * 60 + cacheExpireSeconds;
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(expireSeconds);

                // this is where the data access occurs
                cacheContents = StoredProcMethods.ExecStoredProc(sql, connection);
                
                cache.Set(cacheKey, cacheContents, policy);
            }

            return cacheContents;
        }
    }
}
