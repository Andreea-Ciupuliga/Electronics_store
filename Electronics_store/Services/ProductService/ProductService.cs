using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Electronics_store.Models;
using Electronics_store.Repositories.ProductRepository;

namespace Electronics_store.Services.ProductService
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IQueryable<Product>  GetAllProducts()
        {
            IQueryable<Product>  productsList = _productRepository.GetAllProducts();
            return productsList;
        }

        public Product GetProductByProductId(Guid Id)
        {
            Product product = _productRepository.FindById(Id);
            return product;
        }

        public void CreateProduct(Product entity)
        {
            var productToCreate = new Product
            {
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                CategoryId = entity.CategoryId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };

            _productRepository.Create(productToCreate);
            _productRepository.Save();
        }

        public void DeleteProductById(Guid id)
        {
            Product product = _productRepository.FindById(id);
            _productRepository.Delete(product);
            _productRepository.Save();
        }

        public void UpdateProduct(Product product, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}