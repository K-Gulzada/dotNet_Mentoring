using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Cabinet.Entities
{
    public class Patent : Document
    {
        public DateTime ExpirationDate { get; set; }
        public List<string> Authors { get; set; }     

    }
}
