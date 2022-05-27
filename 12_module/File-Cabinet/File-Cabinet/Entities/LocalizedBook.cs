using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Cabinet.Entities
{
    public class LocalizedBook
    {
        public string ISBN { get; set; } // long?
        public string Title { get; set; }
        public int NumberOfPages { get; set; }
        public string OriginalPublisher { get; set; } // string?
        public string LocalizationCountry { get; set; } // string?
        public string LocalPublisher { get; set; } // string?
        public DateTime PublishedDate { get; set; }
        public List<Author> Authors { get; set; }
    }
}
