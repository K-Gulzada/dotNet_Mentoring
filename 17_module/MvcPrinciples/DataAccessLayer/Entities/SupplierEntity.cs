using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class SupplierEntity
    {
        [Key]
        public int SupplierID { get; set; }
        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }
        [MaxLength(30)]
        public string ContactName { get; set; }
        [MaxLength(24)]
        public string Phone { get; set; }
        [MaxLength(60)]
        public string Address { get; set; }
        [MaxLength(15)]
        public string Country { get; set; }
        [MaxLength(15)]
        public string City { get; set; }
    }
}
