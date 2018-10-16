using System;
using Microsoft.SharePoint;

namespace GeoConnect.DAL.SharePoint
{
    public static class SPConnection
    {
        #region Get Root Absolute URL
        private static string GetRootAboluteURL(string webUrl)
        {
            string absoluteURL = String.Empty;

            try
            {
                if (!webUrl.Contains("http://"))
                {
                    string rootURL = SPContext.Current.Site.WebApplication.Sites[0].Url;

                    if (!webUrl.Contains(rootURL))
                    {
                        if (webUrl.IndexOf('/') == 0)
                            webUrl = rootURL + webUrl;
                        else
                            webUrl = rootURL + "/" + webUrl;
                    }
                }

                absoluteURL = webUrl;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return absoluteURL;
        }
        #endregion

        #region Get List
        public static SPList GetList(string webUrl, string listName)
        {
            SPList tmpList = null;

            try
            {
                string absURL = GetRootAboluteURL(webUrl);

                if (!String.IsNullOrEmpty(absURL))
                {
                    using (SPWeb web = new SPSite(absURL).OpenWeb())
                    {
                        tmpList = web.Lists[listName];
                    }
                }
            }
            catch (Exception ex) 
            {

                throw ex;
            }

            return tmpList;
        }

        #endregion

        #region Get Web
        public static SPWeb GetWeb(string webUrl)
        {
            SPWeb tmpWeb = null;

            try
            {
                string absURL = GetRootAboluteURL(webUrl);

                if (!String.IsNullOrEmpty(absURL))
                    tmpWeb = new SPSite(absURL).OpenWeb();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return tmpWeb;
        }
        #endregion

        #region GetListItemCollection
        public static SPListItemCollection GetListItemCollection(SPQuery query, string WebUrl, string ListName)
        {
            SPListItemCollection collection = null;
            collection = GetList(WebUrl, ListName).GetItems(query);
            return collection;
        }

        public static SPListItemCollection GetListItemCollectionNoQuery(string WebUrl, string ListName)
        {
            SPListItemCollection collection = null;
            collection = GetList(WebUrl, ListName).GetItems();
            return collection;
        }

        #endregion


        public static SPListCollection getLists(string weburl)
        {
            SPListCollection coll = null;
            coll = GetWeb(weburl).Lists;
            return coll;
        }

        public static SPWebCollection getSubsites(string url)
        {
            SPWebCollection coll = null;
            coll = GetWeb(url).Webs;
            return coll;
        }
    }
}
