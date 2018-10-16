using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Text;
using System.Linq;
using GeoConnect.DAL;
using System.Web;
using System.Web.UI;
using GeoConnect.Utilities;


namespace GeoConnect.Intranet.Webparts.Forex
{
    [ToolboxItemAttribute(false)]
    public partial class Forex : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Forex()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!((Page)System.Web.HttpContext.Current.CurrentHandler).IsPostBack)
                {
                    getForexRates(GeoConnect.Utilities.Constants.SPConstants.siteurl, GeoConnect.Utilities.Constants.SPConstants.ForexListName);
                }
            }
            catch (Exception ex)
            {

                lblerror.Visible = true;
                lblerror.Text = ex.Message.ToString();
            }
        }


        private void getForexRates(string url, string listName)
        {
            StringBuilder sb = new StringBuilder();
            SPListItemCollection coll = GeoConnect.DAL.SharePoint.SPConnection.GetListItemCollectionNoQuery(url, listName);
            foreach (SPListItem item in coll)
            {
                string countryName = item["Title"].ToString();
                string value = item["Price"].ToString() + " Rands";
                string country = item["Country"].ToString();
                string glyphicon = "<i class='fa fa-"+ GeoConnect.Utilities.IntranetUtils.getGlyphicon(country)+ "'></i>";

                string html = "<tr><td class='ForexIcon'>" + glyphicon + "</td>";
                html += "<td><div class='forexCountry'>" + country + "</div></td><td><div class='forevValue'>" + value + "</div></td>";
                html += "</tr>";
                sb.Append(html);
            }
            //Adding string builder to the asp.net literal control
            litForex.Text = sb.ToString();
        }

    }
}
