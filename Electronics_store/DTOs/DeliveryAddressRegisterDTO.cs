using System;

namespace Electronics_store.DTOs
{
    public class DeliveryAddressRegisterDTO
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZIPCode { get; set; }
        public Guid OrderId { get; set; }
    }
}