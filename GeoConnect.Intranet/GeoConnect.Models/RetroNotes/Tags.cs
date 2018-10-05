using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoConnect.Models.RetroNotes
{

    public class Tags
    {
        public Tags()
        {
            this.DateCreated = DateTime.Now;
            this.CreatedBy   = System.Environment.UserName;
        }
        public int Id { get; set; }
        public string TagName { get; set; }
        public DateTime DateCreated { get; set; }
        public string CreatedBy { get; set; }
    }

}
