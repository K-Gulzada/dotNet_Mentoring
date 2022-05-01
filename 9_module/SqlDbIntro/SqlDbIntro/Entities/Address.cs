using System.ComponentModel.DataAnnotations;

namespace SqlDbIntro.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Street { get; set; }
        [MaxLength(20)]
        public string? City { get; set; }
        [MaxLength(50)]
        public string? State { get; set; }
        [MaxLength(50)]
        public string? ZipCode { get; set; }
    }
}
