using System;
using System.Collections.Generic;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;

namespace Electronics_store.Repositories.ProductRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        List<Product> GetAllProducts();
        
        Product GetByName(string name);

        public List<Product> GetAllProductsFromACategory(Guid categoryId);
    }
}