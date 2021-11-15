﻿using System;
using System.Collections.Generic;
using Electronics_store.Models.Base;

namespace Electronics_store.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        
        public ICollection<OrderProductRelation> OrderProductRelations { get; set; }
        
        public Category Category { get; set; }
        public Guid CategoryId { get; set; } //FK
    }
}