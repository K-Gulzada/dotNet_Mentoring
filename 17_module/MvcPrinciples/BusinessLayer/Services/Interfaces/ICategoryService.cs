using BusinessLayer.DTO;

namespace BusinessLayer.Services.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        Category GetById(int id);
        Category GetByName(string name);
        void Create(Category category);
        void Update(Category category);
        bool Delete(int id);
    }
}
