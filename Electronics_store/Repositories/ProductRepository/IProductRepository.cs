using System.Linq;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetAllProducts();
    }
}