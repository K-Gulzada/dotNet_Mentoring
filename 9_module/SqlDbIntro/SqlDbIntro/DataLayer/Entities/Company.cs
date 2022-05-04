using System.ComponentModel.DataAnnotations;

namespace SqlDbIntro.DataLayer.Entities
{
    public class Company : BaseModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int AddressId { get; set; }
    }
}
