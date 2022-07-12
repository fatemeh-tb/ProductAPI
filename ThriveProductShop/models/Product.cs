using System;
using System.Collections.Generic;

namespace ProductShop.models
{
    public partial class Product
    {
        public Product()
        {
 
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public decimal? Price { get; set; }
        public int? ProductGroupId { get; set; }

        public virtual ProductGroup? ProductGroup { get; set; }
    }
}
