namespace PresentationLayer.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }  // smallInt => ?? short?? 
        public byte Discontinued { get; set; }  // bit => ??
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public SupplierViewModel SupplierViewModel { get; set; }
        public CategoryViewModel CategoryViewModel { get; set; }
    }
}
