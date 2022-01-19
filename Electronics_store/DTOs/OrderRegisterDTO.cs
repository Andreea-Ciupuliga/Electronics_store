using System;

namespace Electronics_store.DTOs
{
    public class OrderRegisterDTO
    {
        public float TotalPrice { get; set; }

        public Guid UserId { get; set; } //FK
        public Guid ProductId { get; set; } //FK

        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string ZIPCode { get; set; }
    }
}