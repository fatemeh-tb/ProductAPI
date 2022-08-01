

using ProductShop.DataAccess;
using ProductShop.models;
using ProductShop.models.External;

namespace ProductShop.Services
{

    public class DataService
    {
        private readonly ProductRepository _productRepository;

        public DataService()
        {
            _productRepository = new ProductRepository();
        }
        
        
        public int CreateProduct(productDto productDto)
        {
            var product = new Product();
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.ImagePath = productDto.ImagePath;
            product.Price = productDto.Price;
            product.ProductGroupId = productDto.ProductGroupId;
            return _productRepository.CreateProduct(product);
        }


        public int CreateProductGroup(ProductGroupDto productGroupDto)
        {
            var productGroup = new ProductGroup();
            productGroup.Title = productGroupDto.Title;
            return _productRepository.CreateProductGroup(productGroup);
        }
        
        
        public IEnumerable<ProductGroup> GetAll()
        {
            return _productRepository.GetAll();
        }
        
        
        public Product GetProductById(long id)
        {
            return _productRepository.GetProductById(id);
        }
        
        
        public ProductGroup GetProductGroupById(long id)
        {
            return _productRepository.GetProductGroupById(id);
        }

        
        public bool DeleteProduct(long id)
        {
            var product = _productRepository.GetProductById(id);
            return _productRepository.RemoveProduct(product);
        }
        
        
        public bool DeleteProductGroup(long id)
        {
            var product = _productRepository.GetProductGroupById(id);
            return _productRepository.RemoveProductGroup(product);
        }
        
        
        public bool UpdateProduct(productDto productDto)
        {
            return _productRepository.UpdateProduct(productDto);
        }
    }
}

