using System;

namespace Electronics_store.DTOs
{
    public class OrderProductRelationRegisterDTO
    {
        public Guid OrderId { get; set; } //FK

        public Guid ProductId { get; set; } //FK
    }
}