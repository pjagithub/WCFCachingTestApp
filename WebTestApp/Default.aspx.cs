using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebTestApp.PublicServiceReference;
using System.Data;

namespace WebTestApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void btnGetHuxSite_Click(object sender, EventArgs e)
        {
            PublicServiceClient client = new PublicServiceClient();

            // use cache
            DateTime startCache = DateTime.Now;
            DataSet dsCache = client.GetHuxSite();
            DateTime endCache = DateTime.Now;
            TimeSpan tsCache = endCache.Subtract(startCache);

            gvHuxSiteCache.DataSource = dsCache;
            gvHuxSiteCache.DataBind();

            // do not use cache
            DateTime startNoCache = DateTime.Now;
            DataSet dsNoCache = client.GetHuxSiteNoCache();
            DateTime endNoCache = DateTime.Now;
            TimeSpan tsNoCache = endNoCache.Subtract(startNoCache);

            gvHuxSiteNoCache.DataSource = dsNoCache;
            gvHuxSiteNoCache.DataBind();


            lblCacheTime.Text = tsCache.TotalMilliseconds.ToString();
            lblNoCacheTime.Text = tsNoCache.TotalMilliseconds.ToString();
        }
    }
}
