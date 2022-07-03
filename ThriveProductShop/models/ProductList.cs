using System;
using System.Collections.Generic;

namespace ThriveProductShop.models
{
    public partial class ProductList
    {
        public ProductList()
        {
 
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImagePath { get; set; }
        public decimal? Price { get; set; }
        public int? ProductGroupId { get; set; }

        public ProductGroup? ProductGroup { get; set; }
    }
}
