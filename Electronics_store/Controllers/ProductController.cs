using System;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_store.Controllers
{
    [Route("api/[controller]")] //[controller] -> inseamna numele controllerului
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ElectronicsStoreContext _context;

        public ProductController(IProductService productService, ElectronicsStoreContext context)
        {
            _productService = productService;
            _context = context;
        }

        //GET
        [HttpGet("byId/{id}")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_productService.GetProductByProductId(Id));
        }


        [HttpGet("allProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("allProductsFromCategory/{id}")]
        public IActionResult GetAllProductsFromCategory(Guid Id)
        {
            return Ok(_productService.GetAllProductsFromACategory(Id));
        }

        //POST
        [HttpPost("create")]
        public IActionResult Create([FromBody] ProductRegisterDTO product)
        {
            _productService.CreateProduct(product);
            return Ok();
        }

        //PUT
        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] ProductUpdateDTO product, Guid id)
        {
            _productService.UpdateProduct(product, id);
            return Ok();
        }


        //DELETE
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(Guid Id)
        {
            _productService.DeleteProductById(Id);
            return Ok();
        }
    }
}