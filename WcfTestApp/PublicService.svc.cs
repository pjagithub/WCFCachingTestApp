using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfTestApp.cache;
using System.Data;
using WcfTestApp.dal;

namespace WcfTestApp
{
    public class PublicService : IPublicService
    {
        /// <summary>
        /// Use the cache
        /// </summary>
        /// <returns></returns>
        public DataSet GetHuxSite()
        {
            return StoredProcCache.Access(@"huxsite", 0, 15, @"[dbo].[sel_DIM_HUXSITE]", "FieldPerformanceDM");

        }

        /// <summary>
        /// Access the DAL directly
        /// </summary>
        /// <returns></returns>
        public DataSet GetHuxSiteNoCache()
        {
            return StoredProcMethods.ExecStoredProc(@"[dbo].[sel_DIM_HUXSITE]", "FieldPerformanceDM");                                    

        }
    }
}
