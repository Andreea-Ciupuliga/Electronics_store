using System;

namespace Electronics_store.DTOs
{
    public class ProductRegisterDTO
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; } //FK
    }
}