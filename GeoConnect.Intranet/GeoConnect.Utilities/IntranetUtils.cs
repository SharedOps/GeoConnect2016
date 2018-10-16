using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoConnect.Utilities
{
   public static class IntranetUtils
    {
        public static string getGlyphicon(string country)
        {
            string icon = string.Empty;

            if (country == "India")
            {
                icon = "rupee";
            }
            else if (country == "United States")
            {
                icon = "dollar";
            }
            else if (country == "Europe")
            {
                icon = "euro";
            }
            else if (country == "United Kingdom")
            {
                icon = "gbp";
            }
            return icon;
        }
    }
}
