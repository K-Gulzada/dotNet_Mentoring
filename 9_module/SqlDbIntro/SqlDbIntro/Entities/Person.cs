using System.ComponentModel.DataAnnotations;

namespace SqlDbIntro.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

    }
}
