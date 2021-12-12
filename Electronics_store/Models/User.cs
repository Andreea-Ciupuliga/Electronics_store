using System.Collections.Generic;
using Electronics_store.Models.Base;
using Newtonsoft.Json;

namespace Electronics_store.Models
{
    public class User : BaseEntity
    {
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        
        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }
        
        public Role Role { get; set; }
    }
}