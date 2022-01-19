using System;
using System.Collections.Generic;
using System.Linq;
using Electronics_store.Data;
using Electronics_store.Models;
using Electronics_store.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Electronics_store.Repositories.ProductRepository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ElectronicsStoreContext _context;

        public ProductRepository(ElectronicsStoreContext context) : base(context)
        {
            _context = context;
        }
        
        public List<Product> GetAllProducts()
        {
            return new List<Product>(_context.Products.AsNoTracking().ToList());

            //alta varianta 
            
            // return _context.Products.Select(x => new Product
            // {
            //     Id=x.Id,
            //     Name = x.Name,
            //     Price = x.Price,
            //     Description = x.Description,
            //     CategoryId = x.CategoryId,
            //     DateCreated = x.DateCreated,
            //     DateModified = x. DateModified
            // });
            
        }

        public Product GetByName(string name)
        {
            return _context.Products.FirstOrDefault(p=>p.Name.Equals(name));
        }

        public List<Product> GetAllProductsFromACategory(Guid categoryId)
        {
            var result = _table.Join(_context.Categories, product => product.CategoryId ,category => category.Id ,
                (product,category) => new {product,category}).Select(obj => obj.product).Where(obj=>obj.Category.Id.Equals(categoryId));
        
            return result.ToList();
        }
        
    }
}