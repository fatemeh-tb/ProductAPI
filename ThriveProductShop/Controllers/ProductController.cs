using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductShop.models;
using ProductShop.models.External;
using ProductShop.Services;

namespace ProductShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly DataService _dataService;

        public ProductController(ProductShopContext context)
        {
            _dataService = new DataService();
        }

        
        [HttpPost]
        public int CreateProduct(productDto productDto)
        {
            return _dataService.CreateProduct(productDto);
            
        }


        [HttpPost("/productGroup")]
        public int CreateProductGroup(ProductGroupDto productGroupDto)
        {
            return _dataService.CreateProductGroup(productGroupDto);
        }
        
        
        [HttpGet("/All")]
        public IEnumerable<ProductGroup> GetAll()
        {
            return _dataService.GetAll();
        }
        
        
        [HttpGet("{id}")]
        public Product GetProductById(long id)
        {
            return _dataService.GetProductById(id);
        }
        
        
        [HttpGet("/ProductGroups/{id}")]
        public ProductGroup GetProductGroupbyId(long id)
        {
            return _dataService.GetProductGroupById(id);
        }

        
        [HttpDelete("/delete/{id}")]
        public bool DeleteProduct(long id)
        {
            return _dataService.DeleteProduct(id);
        }
        
        
        [HttpDelete("/deleteGroup/{id}")]
        public bool DeleteProductGroup(long id)
        {
            return _dataService.DeleteProductGroup(id);
        }
        
        
        [HttpPut]
        public bool UpdateProduct(productDto productDto)
        {
            return _dataService.UpdateProduct(productDto);
        }

    }
}
