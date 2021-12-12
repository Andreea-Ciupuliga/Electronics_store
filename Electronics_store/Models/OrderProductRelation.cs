using System;
using Newtonsoft.Json;

namespace Electronics_store.Models
{
    public class OrderProductRelation
    {
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}