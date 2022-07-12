using System;
using System.Collections.Generic;

namespace ProductShop.models
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
