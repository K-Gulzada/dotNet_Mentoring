using Models.enums;

namespace Models
{
    public class Order
    {
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int ProductId { get; set; }
    }
}
