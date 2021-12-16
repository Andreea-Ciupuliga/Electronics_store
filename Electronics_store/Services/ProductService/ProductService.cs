using System;
using System.Collections.Generic;
using AutoMapper;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Repositories.ProductRepository;

namespace Electronics_store.Services.ProductService
{
    public class ProductService : IProductService
    {
        public IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<ProductRespondDTO>  GetAllProducts()
        {
            List<Product>  productsList = _productRepository.GetAllProducts();
            List<ProductRespondDTO> productRespondDto  = _mapper.Map<List<ProductRespondDTO>>(productsList);
            return productRespondDto;

        }

        public ProductRespondDTO GetProductByProductId(Guid Id)
        {
            Product product = _productRepository.FindById(Id);
            ProductRespondDTO productRespondDto  = _mapper.Map<ProductRespondDTO>(product);
            return productRespondDto;
        }

        public void CreateProduct(ProductRegisterDTO entity)
        {
            // verific ca numele produsului sa fie unic
            if(_productRepository.GetByName(entity.Name)!=null)
                throw new Exception("Product already exists");
            
            var productToCreate = _mapper.Map<Product>(entity);
            productToCreate.DateCreated = DateTime.Now; 
            productToCreate.DateModified = DateTime.Now; 
            
            //o alta varianta
            
            // var productToCreate = new Product
            // {
            //     Name = entity.Name,
            //     Price = entity.Price,
            //     Description = entity.Description,
            //     CategoryId = entity.CategoryId,
            //     DateCreated = DateTime.Now,
            //     DateModified = DateTime.Now
            // };

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