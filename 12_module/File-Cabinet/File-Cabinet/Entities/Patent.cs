﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Cabinet.Entities
{
    public class Patent
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public List<Author> Authors { get; set; }      
    }
}
