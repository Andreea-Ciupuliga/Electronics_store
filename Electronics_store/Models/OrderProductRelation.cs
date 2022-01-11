using System;
using Electronics_store.Models.Base;
using Newtonsoft.Json;

namespace Electronics_store.Models
{
    public class OrderProductRelation : BaseEntity
    {
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}