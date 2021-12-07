using Electronics_store.Data;
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
    }
}