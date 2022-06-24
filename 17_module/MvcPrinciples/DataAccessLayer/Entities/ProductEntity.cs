using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ProductEntity
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [MaxLength(40)]
        public string ProductName { get; set; }
        [MaxLength(20)]
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }  // smallInt => ?? short?? 
        [Required]
        public bool Discontinued { get; set; }  // bit => ??
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public SupplierEntity Supplier { get; set; }
        public CategoryEntity Category { get; set; }

    }
}
