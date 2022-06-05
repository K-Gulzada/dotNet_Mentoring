
namespace AdoNetFundamentals.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public Product(string name, string description, float weight, float height, float width, float length)
        {
            Name = name;
            Description = description;
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;
        }

        public Product(int id, string name, string description, float weight, float height, float width, float length)
        {
            Id = id;
            Name = name;
            Description = description;
            Weight = weight;
            Height = height;
            Width = width;
            Length = length;
        }
    }
}