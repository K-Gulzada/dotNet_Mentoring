

namespace AdoNetFundamentals.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
        public Order(DateTime createdDate, DateTime updatedDate, Status status, int productId)
        {
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            Status = status;
            ProductId = productId;
        }
    }
}
