using System;
using System.Collections.Generic;
using AutoMapper;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.CategoryRepository;

namespace Electronics_store.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public List<CategoryRespondDTO> GetAllCategories()
        {
            List<Category> categoriesList = _categoryRepository.GetAllCategories();
            List<CategoryRespondDTO> categoryRespondDTO  = _mapper.Map<List<CategoryRespondDTO>>(categoriesList);
            return categoryRespondDTO;
        }

        public CategoryRespondDTO GetCategoryByCategoryId(Guid Id)
        {
            Category category = _categoryRepository.FindById(Id);
            CategoryRespondDTO categoryRespondDTO  = _mapper.Map<CategoryRespondDTO>(category);
            return categoryRespondDTO;
        }

        public void CreateCategory(CategoryRegisterDTO entity)
        {
            if(_categoryRepository.GetByName(entity.Name)!=null)
                throw new Exception("Category already exists");
            
            var categoryToCreate =_mapper.Map<Category>(entity);
            categoryToCreate.DateCreated= DateTime.Now;
            categoryToCreate.DateModified= DateTime.Now;
            
            
            //alta varianta
            
            // var categoryToCreate = new Category
            // {
            //     Name = entity.Name,
            //     DateCreated = DateTime.Now,
            //     DateModified = DateTime.Now
            // };

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