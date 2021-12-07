using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics_store.Models;

namespace Electronics_store.Services.ProductService
{
    public interface IProductService
    {
        public IQueryable<Product> GetAllProducts();
        
        Product GetProductByProductId(Guid Id);
        
        void CreateProduct(Product entity);
        
        void DeleteProductById(Guid id);
        
        void UpdateProduct(Product product, Guid id);
    }
}