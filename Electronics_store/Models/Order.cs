using System;
using System.Collections.Generic;
using Electronics_store.Models.Base;
using Newtonsoft.Json;

namespace Electronics_store.Models
{
    public class Order : BaseEntity
    {
        public float TotalPrice { get; set; }
        
        [JsonIgnore]
        public User User { get; set; }
        
        public Guid UserId { get; set; } //FK
        
        [JsonIgnore]
        public DeliveryAddress DeliveryAddress { get; set; }
        
        [JsonIgnore]
        public ICollection<OrderProductRelation> OrderProductRelations { get; set; }
    }
}