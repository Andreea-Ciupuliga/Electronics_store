using System;
using System.Collections.Generic;
using Electronics_store.DTOs;
using Electronics_store.Models;

namespace Electronics_store.Services.ProductService
{
    public interface IProductService
    {
        public List<ProductRespondDTO> GetAllProducts();
        
        ProductRespondDTO GetProductByProductId(Guid Id);
        
        void CreateProduct(ProductRegisterDTO entity);
        
        void DeleteProductById(Guid id);
        
        void UpdateProduct(Product product, Guid id);
    }
}