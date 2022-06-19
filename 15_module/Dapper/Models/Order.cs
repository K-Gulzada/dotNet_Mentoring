using Models.enums;

namespace Models
{
    public class Order
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
