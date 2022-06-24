using Microsoft.AspNetCore.Http;

namespace BusinessLayer.DTO
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        //   public Image Picture { get; set; }
        public IFormFile Picture { get; set; }
    }
}
