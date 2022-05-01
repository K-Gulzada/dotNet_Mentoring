using System.ComponentModel.DataAnnotations;

namespace SqlDbIntro.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AddressId { get; set; }
        [Required]
        public int PersonId { get; set; }
        [Required]
        [MaxLength(20)]       
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string? Position { get; set; }
        [MaxLength(100)]
        public string? EmployeeName { get; set; }
        public virtual Address Address{ get; set; }
        public virtual Person Person{ get; set; }
    }
}
