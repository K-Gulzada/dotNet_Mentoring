using System.ComponentModel.DataAnnotations;

namespace SqlDbIntro.DataLayer.Entities
{
    public class Person : BaseModel
    {
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

    }
}
