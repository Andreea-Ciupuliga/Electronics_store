using System;
using System.Collections.Generic;
using System.Linq;
using Electronics_store.Data;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Electronics_store.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ElectronicsStoreContext _context;

        public CategoryRepository(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }

        public List<Category> GetAllCategories()
        {
            return new List<Category>(_context.Categories.AsNoTracking().ToList());
            
            //alta varianta
            
            // return _context.Categories.Select(x => new Category
            // {
            //     Id=x.Id,
            //     Name = x.Name,
            //     DateCreated = x.DateCreated,
            //     DateModified = x. DateModified
            // });
        }

        public Category GetByName(string name)
        {
            return _context.Categories.FirstOrDefault(c=>c.Name.Equals(name));
        }
    }
}