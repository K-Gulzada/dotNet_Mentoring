using System.ComponentModel.DataAnnotations;

namespace SqlDbIntro.Entities
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int AddressId { get; set; }
    }
}
