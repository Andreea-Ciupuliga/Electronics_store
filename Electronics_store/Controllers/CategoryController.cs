using System;
using Electronics_store.Data;
using Electronics_store.DTOs;
using Electronics_store.Models;
using Electronics_store.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Electronics_store.Controllers
{
    [Route("api/[controller]")] //[controller] -> inseamna numele controllerului
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ElectronicsStoreContext _context;

        public CategoryController(ICategoryService categoryService,ElectronicsStoreContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }
        
        //GET
        [HttpGet("byId/{id}")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_categoryService.GetCategoryByCategoryId(Id));
        }
        
       
        [HttpGet("allCategories")]
        public IActionResult GetAllCategories() 
        {
            return Ok(_categoryService.GetAllCategories());
        }
        
        
        //POST
        [HttpPost("create")]
        public IActionResult Create([FromBody] CategoryRegisterDTO category)
        {
            _categoryService.CreateCategory(category);
            return Ok();
        }
        
        //PUT
        [HttpPut("update/{id}")]
        public IActionResult Update([FromBody] CategoryRegisterDTO category, Guid id)
        {
            _categoryService.UpdateCategory(category,id);
            return Ok();
        }
        
        
        //DELETE
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(Guid Id)
        {
            _categoryService.DeleteCategoryById(Id);
            return Ok();
        }
    }
}