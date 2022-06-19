using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkIntro.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
    }
}