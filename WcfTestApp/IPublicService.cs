using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace WcfTestApp
{
    [ServiceContract]
    public interface IPublicService
    {
        [OperationContract]
        DataSet GetHuxSite();

        [OperationContract]
        DataSet GetHuxSiteNoCache();
    }
}
