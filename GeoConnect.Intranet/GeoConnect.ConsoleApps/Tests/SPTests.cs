using System;
using Microsoft.SharePoint;
using GeoConnect.DAL;

namespace GeoConnect.ConsoleApps.Tests
{
    public static class SPTests
    {
        public static void getListItems()
        {
            try
            {
                using (SPSite site = new SPSite(GeoConnect.Utilities.Constants.SPConstants.siteurl))
                {
                    SPWeb web = site.OpenWeb();
                    SPList list = web.Lists[GeoConnect.Utilities.Constants.SPConstants.IntranetNewsListName];
                    SPListItemCollection coll = list.GetItems();
                    int count = coll.Count;
                    if (count != 0)
                    {
                        foreach (SPListItem item in coll)
                        {
                            Console.WriteLine(item["Title"].ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No items available at this moment in " + list.Title);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public static void getListItems(string url,string listname)
        {
            SPListItemCollection lists = GeoConnect.DAL.SharePoint.SPConnection.GetListItemCollectionNoQuery(url, listname);
            foreach (SPItem item in lists)
            {
                Console.WriteLine(item[0].ToString()+"   "+ item[3].ToString() + "   " + item[4].ToString());
            }
           
        }
        public static void getItemsFromUtility(string url, string listname)
        {
            SPListItemCollection coll = GeoConnect.DAL.SharePoint.SPConnection.GetListItemCollectionNoQuery(url, listname);
            int count = coll.Count;
            if (count != 0)
            {
                foreach (SPListItem item in coll)
                {
                    Console.WriteLine(item["Title"].ToString());
                }
            }
            else
            {
                Console.WriteLine("No items available at this moment in " + coll.List.Title);
            }
        }

        #region sites in a particular web application
        public static void getSites(String url)
        {
            using (SPSite site = new SPSite(url))
            {
                foreach (SPWeb web in site.AllWebs)
                {
                    Console.WriteLine(web.Title);
                }
            }
        }
        #endregion


        //Get Sub Sites
        public static void getSubSites(String url)
        {
            SPWebCollection coll = GeoConnect.DAL.SharePoint.SPConnection.getSubsites(url);
            foreach (SPWeb subsite in coll)
            {
                Console.WriteLine(subsite.Title);
            }
        }

        //Get All Lists in a web
        public static void getLists(String url)
        {
            try
            {
                SPListCollection coll = GeoConnect.DAL.SharePoint.SPConnection.getLists(url);
                foreach (SPList list in coll)
                {
                    Console.WriteLine(list.Title);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

    }
}
