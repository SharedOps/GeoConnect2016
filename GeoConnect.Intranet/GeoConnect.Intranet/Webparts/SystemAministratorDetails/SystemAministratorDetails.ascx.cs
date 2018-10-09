using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Data;

namespace GeoConnect.Intranet.Webparts.SystemAministratorDetails
{
    [ToolboxItemAttribute(false)]
    public partial class SystemAministratorDetails : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public SystemAministratorDetails()
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
                var web = SPContext.Current.Web;
                getIntranetNews(web.Url, "Intranet News");


            }
            catch (Exception ex)
            {
                lblSystemAdministratordetails.Text = "site Url " + ex.Message.ToString();
            }
        }


        private void getIntranetNews(string url, string listname)
        {
            try
            {
                using (SPSite site = new SPSite(url))
                {
                    SPWeb web = site.OpenWeb();
                    SPList list = web.Lists[listname];
                    SPListItemCollection coll = list.GetItems();
                    DataTable dt = coll.GetDataTable();
                    grdListView.DataSource = dt;
                    grdListView.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblSystemAdministratordetails.Text = ex.Message.ToString();
            }

        }
    }
}
