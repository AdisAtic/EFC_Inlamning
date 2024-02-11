using DataLayer.Entities;
using DataLayer.Repositories;

namespace DataLayer.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }





        public CategoryEntity CreateCategory(string categoryName)
        {
            var categoryModel = _categoryRepository.Get(x => x.CategoryName == categoryName);
            categoryModel ??= _categoryRepository.Create(new CategoryEntity { CategoryName = categoryName });

            return categoryModel;
        }

        public CategoryEntity GetCategoryByCategoryName(string categoryName)
        {
            var categoryModel = _categoryRepository.Get(x => x.CategoryName == categoryName);
            return categoryModel;
        }

        public CategoryEntity GetCategoryById(int id)
        {
            var categoryModel = _categoryRepository.Get(x => x.Id == id);
            return categoryModel;
        }

        public IEnumerable<CategoryEntity> GetCategories()
        {
            var categories = _categoryRepository.GetAll();
            return categories;  //59:41//
        }

        public CategoryEntity UpdateCategory(CategoryEntity categoryModel)
        {
            var updatedCategoryModel = _categoryRepository.Update(x => x.Id == categoryModel.Id, categoryModel);
            return updatedCategoryModel;
        }

        public void DeleteCategory(int id) 
        {
            _categoryRepository.Delete(x => x.Id == id);
        }
    }
}
