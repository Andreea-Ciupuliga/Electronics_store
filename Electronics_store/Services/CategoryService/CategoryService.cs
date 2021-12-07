using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Electronics_store.Models;
using Electronics_store.Repositories.CategoryRepository;

namespace Electronics_store.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<List<Category>> GetAllCategories()
        {
            Task<List<Category>> categoriesList = _categoryRepository.GetAll();
            return categoriesList;
        }

        public Category GetCategoryByCategoryId(Guid Id)
        {
            Category category = _categoryRepository.FindById(Id);
            return category;
        }

        public void CreateCategory(Category entity)
        {
            var categoryToCreate = new Category
            {
                Name = entity.Name,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _categoryRepository.Create(categoryToCreate);
            _categoryRepository.Save();
        }

        public void DeleteCategoryById(Guid id)
        {
            Category category = _categoryRepository.FindById(id);
            _categoryRepository.Delete(category);
            _categoryRepository.Save();
        }

        public void UpdateCategory(Category category, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}