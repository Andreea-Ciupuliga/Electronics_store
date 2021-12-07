using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics_store.Models;

namespace Electronics_store.Services.CategoryService
{
    public interface ICategoryService
    {
        public IQueryable<Category> GetAllCategories();

        Category GetCategoryByCategoryId(Guid Id);

        void CreateCategory(Category entity);

        void DeleteCategoryById(Guid id);

        void UpdateCategory(Category category, Guid id);
    }
}