using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ThriveProductShop.models;


namespace ThriveProductShop.DataAccess
{
    public class ProductRepository
    {
        private readonly ThriveProductShopContext _dbContext = new ThriveProductShopContext();

        
        public int Create(ProductGroup product)
        {
            using var db = new ThriveProductShopContext();
            db.ProductGroups.Add(product);
            var result = db.SaveChanges();

            return result;
        }

        public List<ProductList> GetAll()
        {
            using var db = new ThriveProductShopContext();
            var products = db.ProductLists.ToList();
            return products;
        }
        
        public IEnumerable<ProductGroup> GetAllGroups()
        {
            var groups = _dbContext
                .ProductGroups
                .Select(t => new ProductGroup()
                {
                    Id = t.Id,
                    Title = t.Title,
                    ProductLists = (ICollection<ProductList>) t.ProductLists.Select(p => new ProductList()
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

        public ProductList GetById(long id)
        {
            using var db = new ThriveProductShopContext();
            var product = db.ProductLists.SingleOrDefault(p => p.Id == id);
            return product;
        }
        
        
        public bool Remove(ProductList product)
        {
            using var db = new ThriveProductShopContext();
            db.ProductLists.Attach(product);
            db.ProductLists.Remove(product);
            return db.SaveChanges() > 0;
        }
        
        public bool Update(ProductGroup product)
        {
            using var db = new ThriveProductShopContext();
            var productToUpdate = db.ProductGroups.FirstOrDefault(p => p.Id == product.Id);
            if (productToUpdate is not null)
            {
                productToUpdate.Title = product.Title;
                productToUpdate.ProductLists = product.ProductLists;
                return db.SaveChanges() > 0;
            }

            return false;
        }

    }
}