﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTO
{
    public class Product
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
        public byte Discontinued { get; set; }  // bit => ??
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public Supplier Supplier { get; set; }
        public Category Category { get; set; }

    }
}
