using System;
using System.Collections.Generic;

namespace ThriveProductShop.models
{
    public partial class ProductGroup
    {
        public ProductGroup()
        {
            ProductLists = new HashSet<ProductList>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }

        public virtual ICollection<ProductList> ProductLists { get; set; }
    }
}
