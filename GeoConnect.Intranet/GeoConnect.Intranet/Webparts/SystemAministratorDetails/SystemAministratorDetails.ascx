<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SystemAministratorDetails.ascx.cs" Inherits="GeoConnect.Intranet.Webparts.SystemAministratorDetails.SystemAministratorDetails" %>

<asp:Label ID="lblSystemAdministratordetails" runat="server"></asp:Label>

<asp:GridView ID="grdListView" runat="server">


</asp:GridView>
<link href="../../_layouts/16/GeoConnect.Intranet/BootStrap/bootstrap.min.css" rel="stylesheet" />
<script src="../../_layouts/16/GeoConnect.Intranet/BootStrap/jquery.min.js"></script>
<script src="../../_layouts/16/GeoConnect.Intranet/BootStrap/bootstrap.min.js"></script>
