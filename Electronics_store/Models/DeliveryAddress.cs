using System;
using Electronics_store.Models.Base;
using Newtonsoft.Json;

namespace Electronics_store.Models

{
    public class DeliveryAddress : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZIPCode { get; set; }
        [JsonIgnore]
        public Order Order { get; set; }
        [JsonIgnore]
        public Guid OrderId { get; set; }
    }
}