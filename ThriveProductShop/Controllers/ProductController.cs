using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThriveProductShop.models;
using ThriveProductShop.Services;

namespace ThriveProductShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataService _dataService;

        public ProductController(ThriveProductShopContext context)
        {
            _dataService = new DataService();
        }

        
        [HttpPost]
        public int CreateProduct(ProductGroup product)
        {
            return _dataService.CreateProduct(product);
            
        }

        
        [HttpGet("/all")]
        public List<ProductList> GetProducts()
        {
            return _dataService.GetProducts();
        }
        
        
        [HttpGet]
        public IEnumerable<ProductGroup> GetProductsGroup()
        {
            return _dataService.GetProductsGroup();
        }
        
        
        [HttpGet("{id}")]
        public ProductList GetProductById(long id)
        {
            return _dataService.GetProductById(id);
        }

        
        [HttpDelete("/delete/{id}")]
        public bool DeleteProduct(long id)
        {
            return _dataService.DeleteProduct(id);
        }
        
        
        [HttpPut]
        public bool UpdateProduct(ProductGroup product)
        {
            return _dataService.UpdateProduct(product);
        }

    }
}
