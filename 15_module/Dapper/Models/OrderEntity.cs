using Models.enums;

namespace Models
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
