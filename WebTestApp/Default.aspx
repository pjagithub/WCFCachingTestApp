<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebTestApp._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <h2>ASP.NET WEB FORM ACCESS</h2>

    <table>
        <tr>
            <td>
                <asp:Button ID="btnGetHuxSite" runat="server" Text="Hux Sites" onclick="btnGetHuxSite_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Cache"></asp:Label>
                <asp:Label ID="lblCacheTime" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvHuxSiteCache" runat="server"></asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="No Cache"></asp:Label>
                <asp:Label ID="lblNoCacheTime" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvHuxSiteNoCache" runat="server"></asp:GridView>
            </td>
        </tr>
    </table>

    <h2>SILVERLIGHT ACCESS</h2>

    <table>    
        <tr>
            <td>
                <div id="silverlightControlHost">
                    <object data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="400" height="300">
		              <param name="source" value="ClientBin/SilverlightTestApp.xap"/>
		              <param name="onError" value="onSilverlightError" />
		              <param name="background" value="white" />
		              <param name="minRuntimeVersion" value="4.0.50826.0" />
		              <param name="autoUpgrade" value="true" />
		              <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=4.0.50826.0" style="text-decoration:none">
 			              <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight" style="border-style:none"/>
		              </a>
	                </object><iframe id="_sl_historyFrame" style="visibility:hidden;height:0px;width:0px;border:0px"></iframe>
                </div>
            </td>
        </tr>
    </table>

</asp:Content>
