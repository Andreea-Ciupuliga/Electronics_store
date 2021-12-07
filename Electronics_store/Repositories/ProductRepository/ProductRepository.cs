using System.Linq;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ElectronicsStoreContext _context;

        public ProductRepository(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }
        
        public IQueryable<Product> GetAllProducts()
        {
            return _context.Products.Select(x => new Product
            {
                Id=x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                CategoryId = x.CategoryId,
                DateCreated = x.DateCreated,
                DateModified = x. DateModified
            });
        }
    }
}