using System;
using System.Linq;
using Electronics_store.Data;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ElectronicsStoreContext _context;

        public CategoryRepository(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _context.Categories.Select(x => new Category
            {
                Id=x.Id,
                Name = x.Name,
                DateCreated = x.DateCreated,
                DateModified = x. DateModified
            });
        }
    }
}