using System.Collections.Generic;
using Electronics_store.Models.Base;

namespace Electronics_store.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}