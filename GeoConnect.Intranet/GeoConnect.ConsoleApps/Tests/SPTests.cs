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
                        Console.WriteLine("No items available at this moment in "+ list.Title);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }


        public static void getItemsFromUtility(string url, string listname)
        {
            SPListItemCollection coll = GeoConnect.DAL.SharePoint.SPConnection.GetListItemCollectionNoQuery(url,listname);
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

    }
}
