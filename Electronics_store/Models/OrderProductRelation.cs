﻿using System;

namespace Electronics_store.Models
{
    public class OrderProductRelation
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}