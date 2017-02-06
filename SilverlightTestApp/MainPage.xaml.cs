using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightTestApp.PublicServiceReference;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace SilverlightTestApp
{
    public partial class MainPage : UserControl
    {
        PublicServiceClient client;

        public MainPage()
        {
            InitializeComponent();

            client = new PublicServiceClient();
            client.GetHuxSiteCompleted += new EventHandler<GetHuxSiteCompletedEventArgs>(client_GetHuxSiteCompleted);
            client.GetHuxSiteNoCacheCompleted += new EventHandler<GetHuxSiteNoCacheCompletedEventArgs>(client_GetHuxSiteNoCacheCompleted);
        }

        void client_GetHuxSiteCompleted(object sender, GetHuxSiteCompletedEventArgs e)
        {
            dgHuxSites.ItemsSource = DeserializeHuxSiteData(e.Result);
        }

        void client_GetHuxSiteNoCacheCompleted(object sender, GetHuxSiteNoCacheCompletedEventArgs e)
        {
            dgHuxSitesNoCache.ItemsSource = DeserializeHuxSiteData(e.Result);
        }

        /// <summary>
        /// Get the data we need from the xml that is returned from the WCF call. 
        /// The WCF endpoint returns a dataset, which is returned to Silverlight as an ArrayOfXElement type - see example below
        /// 
        /// e.Result.Nodes[0] contains XSL type descriptive data
        /// <xs:schema id="NewDataSet" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns="" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
        ///  <xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:UseCurrentLocale="true">
        ///    <xs:complexType>
        ///      <xs:choice minOccurs="0" maxOccurs="unbounded">
        ///        <xs:element name="Table">
        ///          <xs:complexType>
        ///            <xs:sequence>
        ///              <xs:element name="DIMHuxSiteID" type="xs:int" minOccurs="0" />
        ///              <xs:element name="HuxSiteName" type="xs:string" minOccurs="0" />
        ///              <xs:element name="LastUpdated" type="xs:dateTime" minOccurs="0" />
        ///            </xs:sequence>
        ///          </xs:complexType>
        ///        </xs:element>
        ///      </xs:choice>
        ///    </xs:complexType>
        ///  </xs:element>
        /// </xs:schema>
        /// e.Result.Nodes[1] contains the actual dataset data
        ///  <diffgr:diffgram xmlns:diffgr="urn:schemas-microsoft-com:xml-diffgram-v1" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
        ///    <NewDataSet xmlns="">
        ///      <Table diffgr:id="Table1" msdata:rowOrder="0">
        ///        <DIMHuxSiteID>1</DIMHuxSiteID>
        ///        <HuxSiteName>Longmont</HuxSiteName>
        ///        <LastUpdated>2011-05-26T11:49:02.7-06:00</LastUpdated>
        ///      </Table>
        ///      <Table diffgr:id="Table2" msdata:rowOrder="1">
        ///        <DIMHuxSiteID>2</DIMHuxSiteID>
        ///        <HuxSiteName>Texas</HuxSiteName>
        ///        <LastUpdated>2011-05-26T11:49:02.7-06:00</LastUpdated>
        ///      </Table>
        ///    </NewDataSet>
        ///  </diffgr:diffgram>
        ///  
        /// </summary>
        /// <param name="array">Data returned from the WCF call</param>
        /// <returns></returns>
        private ObservableCollection<GridData> DeserializeHuxSiteData(ArrayOfXElement array)
        {
            ObservableCollection<GridData> data = new ObservableCollection<GridData>();

            IEnumerable<XElement> collection = array.Nodes[1].Element("NewDataSet").Elements("Table");
            foreach (XElement element in collection)
            {
                data.Add(new GridData()
                {
                    DIMHuxSiteID = int.Parse(element.Element("DIMHuxSiteID").Value),
                    HuxSiteName = element.Element("HuxSiteName").Value,
                    LastUpdated = DateTime.Parse(element.Element("LastUpdated").Value)
                });
            }

            return data;
        }

        private void btnGetHuxSites_Click(object sender, RoutedEventArgs e)
        {
            client.GetHuxSiteAsync();
            client.GetHuxSiteNoCacheAsync();
        }
    }

    /// <summary>
    /// This class must match the xml data returned from the WCF service
    /// </summary>
    public class GridData
    {
        public int DIMHuxSiteID { get; set; }
        public string HuxSiteName { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
