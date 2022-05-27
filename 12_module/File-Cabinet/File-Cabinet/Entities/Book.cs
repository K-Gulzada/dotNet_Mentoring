using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Cabinet.Entities
{
    public class Book
    {
        public string ISBN { get; set; } // long?
        public string Title { get; set; }
        public List<Author> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; } // string?
        public DateTime PublishedDate { get; set; }
        Localized book(ISBN, title, authors, number of pages, original publisher, country of localization, local publisher, date published)
    }
}
