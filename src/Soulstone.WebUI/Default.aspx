<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Soulstone.WebUI.Default" MasterPageFile="~/Soulstone.Master" Title="Soulstone"%>

<%@ Register Assembly="System.Web.Silverlight" Namespace="System.Web.UI.SilverlightControls"
    TagPrefix="asp" %>
        
<asp:Content ContentPlaceHolderID="BodyPlaceHolder" runat="server">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="text-align:center">
            <asp:Silverlight ID="SoulstoneSL" runat="server" Source="~/ClientBin/Soulstone.SL.xap" MinimumVersion="2.0.31005.0" Width="800px" Height="500px" />
        </div>
    </form>
    <form id="generateFileForm" action="DownloadFile.aspx" method="post">
        <input runat="server" type="hidden" id="downloadData" />
        <input runat="server" type="hidden" id="fileName" />
    </form>
</asp:Content>