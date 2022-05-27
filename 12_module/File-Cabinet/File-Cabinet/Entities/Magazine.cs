using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Cabinet.Entities
{
   public class Magazine
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int ReleaseNumber { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
