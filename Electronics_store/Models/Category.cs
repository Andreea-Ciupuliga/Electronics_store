﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using Electronics_store.Models.Base;

namespace Electronics_store.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}