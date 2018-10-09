using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;

namespace GeoConnect.Intranet.Webparts.IntranetNews
{
    [ToolboxItemAttribute(false)]
    public partial class IntranetNews : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public IntranetNews()
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
                Label1.Text = web.Title + web.Description +" "+ web.IsRootWeb;

                Label2.Text =web.Url.ToString() ;
                
            }
            catch (Exception ex)
            {

                Label1.Text = ex.Message.ToString();
            }

        }

       
    }
}
