using System.ComponentModel.DataAnnotations;


namespace SqlDbIntro.DataLayer.Entities
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
