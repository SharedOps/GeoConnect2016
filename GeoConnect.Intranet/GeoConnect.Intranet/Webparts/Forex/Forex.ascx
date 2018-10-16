<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Forex.ascx.cs" Inherits="GeoConnect.Intranet.Webparts.Forex.Forex" %>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
   <ContentTemplate>
       <div class="panel panel-default">
           <div class="panel-heading">Forex Rates vs Rand</div>
           <div class="panel-body">
               <table class="tbl-Forex table table-borderless table-condensed table-hover">
                   <asp:Literal ID="litForex" runat="server">
        
                   </asp:Literal>
               </table>
           </div>
       </div>

       <asp:Label ID="lblerror" CssClass="error" runat="server" Text="" Visible="false"></asp:Label>
   </ContentTemplate>
</asp:UpdatePanel>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>
