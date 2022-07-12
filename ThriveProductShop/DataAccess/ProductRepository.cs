using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.models;


namespace ProductShop.DataAccess
{
    public class ProductRepository
    {
        private readonly ProductShopContext _dbContext = new ProductShopContext();

        
        public int CreateProduct(Product product)
        {
            using var db = new ProductShopContext();
            db.Products.Add(product);
            var result = db.SaveChanges();
            return result;
        }


        public int CreateProductGroup(ProductGroup productGroup)
        {
            using var db = new ProductShopContext();
            db.ProductGroups.Add(productGroup);
            var result = db.SaveChanges();
            return result;
        }
        
        
        public IEnumerable<ProductGroup> GetAll()
        {
            var groups = _dbContext
                .ProductGroups
                .Select(t => new ProductGroup()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Products = (ICollection<Product>) t.Products.Select(p => new Product()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        ImagePath = p.ImagePath,
                        Price = p.Price,
                    })
                }).ToList();

            return groups;
        }

        
        public Product GetProductById(long id)
        {
            using var db = new ProductShopContext();
            var product = db.Products.SingleOrDefault(p => p.Id == id);
            return product;
        }

        
        public ProductGroup GetProductGroupById(long id)
        {
            using var db = new ProductShopContext();
            var product = db.ProductGroups.SingleOrDefault(p => p.Id == id);
            return product;
        }
        
        
        public bool RemoveProduct(Product product)
        {
            using var db = new ProductShopContext();
            db.Products.Attach(product);
            db.Products.Remove(product);
            return db.SaveChanges() > 0;
        }
        
        
        public bool RemoveProductGroup(ProductGroup productGroup)
        {
            using var db = new ProductShopContext();
            db.ProductGroups.Attach(productGroup);
            db.ProductGroups.Remove(productGroup);
            return db.SaveChanges() > 0;
        }

        
        public bool UpdateProduct(ProductGroup product)
        {
            using var db = new ProductShopContext();
            var productToUpdate = db.ProductGroups.FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate is not null)
            {
                productToUpdate.Title = product.Title;
                productToUpdate.Products = product.Products;
                return db.SaveChanges() > 0;
            }

            return false;
        }

    }
}