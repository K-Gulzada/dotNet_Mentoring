using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(15)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }
}
