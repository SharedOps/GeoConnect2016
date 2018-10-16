using System;
using Microsoft.SharePoint;
using GeoConnect.DAL;
using Microsoft.SharePoint.Administration;

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


        public static void getListItemsWithQuery(string url, string listname)
        {
            string filter = "HR";
            SPQuery query = new SPQuery();
            query.Query = "<Where><Eq><FieldRef Name='NewsType' /><Value Type='Choice'>"+filter+"</Value></Eq></Where><OrderBy><FieldRef Name='Created' Ascending='False' /></OrderBy>";
            query.ViewFields = "<FieldRef Name='Title' /><FieldRef Name='NewsType' /><FieldRef Name='KpiDescription' /><FieldRef Name='ID' />";
            SPListItemCollection lists = GeoConnect.DAL.SharePoint.SPConnection.GetListItemCollection(query,url, listname);
            foreach (SPItem item in lists)
            {
                Console.WriteLine(item["Title"].ToString());
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

        // sites in a particular web application
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

        public static void getWeb(string url)
        {
            SPWeb web = GeoConnect.DAL.SharePoint.SPConnection.GetWeb(url);
            Console.WriteLine(web.Title);
        }

        public static void getAllWebApplications()
        {
            string web2 = "";
            SPWebApplicationCollection colWebApll = SPWebService.ContentService.WebApplications;
            foreach (SPWebApplication webApp in colWebApll)
            {
                web2 += "Web Application Name (SPWebApplication):"+webApp.Name+"\n"; ;
                for (int i = 0; i < webApp.Sites.Count; i++)
                {                  
                    SPSite site = webApp.Sites[i];
                    web2 += "Site Collection URL (SPSite):"+site.Url+"\n"; ;
                    for (int j = 0; j < site.AllWebs.Count; j++)
                    {
                        
                        SPWeb web = site.AllWebs[j];
                        for (int k= 0; k < web.Webs.Count; k++)
                        {
                            SPWeb web1 = web.Webs[k];
                            web2 += "Sub Sites URL(SPWeb):"+web1.Url+"\n"; ;                                                  
                        }                    
                    }
                    web2 += "\n";
                }
                web2 += "-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐-­‐\n";
            }
            Console.WriteLine(web2);
        }        
    }
}
