using System;

namespace Electronics_store.DTOs
{
    public class OrderRegisterDTO
    {
        public float TotalPrice { get; set; }

        public Guid UserId { get; set; } //FK
        
    }
}