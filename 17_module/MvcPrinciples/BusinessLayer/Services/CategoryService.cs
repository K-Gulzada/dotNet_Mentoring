using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;
using ReflectionIT.Mvc.Paging;

namespace BusinessLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private protected IUnitOfWork _database;
        private protected IMapper _mapper;
        public CategoryService(IUnitOfWork database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public List<Category> GetCategoryList()
        {
            var categoryEntities = _database.Categories.GetAll();
            var categories = categoryEntities.Select(c => _mapper.Map<Category>(c)).ToList();

            return categories;
        }

        public PagingList<Category> GetAllCategory(int pageSize, int page)
        {
            var categoryEntities = _database.Categories.GetAll();
            var categories = categoryEntities.Select(c => _mapper.Map<Category>(c)).ToList();
            var model = PagingList.Create(categories, pageSize, page);
            model.Action = "CategoryList";

            return model;
        }

        public Category GetById(int id)
        {
            var categoryEntity = _database.Categories.Get(id);

            return _mapper.Map<Category>(categoryEntity);
        }

        public Category GetByName(string name)
        {
            var categoryEntity = _database.Categories.Get(name);

            return _mapper.Map<Category>(categoryEntity);
        }

        public List<string> GetAllCategoryNames()
        {
            var categoryEntities = _database.Categories.GetAll();
            var categoryNames = categoryEntities.Select(x => x.CategoryName).ToList();

            return categoryNames;
        }

        public void Create(Category category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);
            _database.Categories.Create(categoryEntity);
            _database.Save();
        }

        public bool Delete(int id)
        {
            var isSuccess = _database.Categories.Delete(id);
            _database.Save();

            return isSuccess;
        }

        public void Update(Category category)
        {
            var categoryEntity = _mapper.Map<CategoryEntity>(category);
            _database.Categories.Update(categoryEntity);
            _database.Save();
        }
    }
}
