using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlDbIntro.BusinessLayer.ViewModels
{
    public class EmployeeVM
    {
        public int AddressId { get; set; }
        public int PersonId { get; set; }
        public string CompanyName { get; set; }
        public string? Position { get; set; }
        public virtual AddressVM AddressVM { get; set; }
        public virtual PersonVM PersonVM { get; set; }
    }
}
