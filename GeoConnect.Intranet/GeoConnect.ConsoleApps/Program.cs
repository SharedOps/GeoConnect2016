using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoConnect.ConsoleApps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url      = GeoConnect.Utilities.Constants.SPConstants.siteurl;
                string listname = GeoConnect.Utilities.Constants.SPConstants.IntranetNewsListName;

                GeoConnect.ConsoleApps.Tests.SPTests.getListItems(url, listname);
                Console.ReadLine();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }       
    }
}
