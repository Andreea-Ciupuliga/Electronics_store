using System;
using System.Collections.Generic;
using Electronics_store.DTOs;
using Electronics_store.Models;

namespace Electronics_store.Services.CategoryService
{
    public interface ICategoryService
    {
        public List<CategoryRespondDTO> GetAllCategories();

        CategoryRespondDTO GetCategoryByCategoryId(Guid Id);

        void CreateCategory(CategoryRegisterDTO entity);

        void DeleteCategoryById(Guid id);

        void UpdateCategory(Category category, Guid id);
    }
}