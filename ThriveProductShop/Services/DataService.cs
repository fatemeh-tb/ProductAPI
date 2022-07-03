

using ThriveProductShop.DataAccess;
using ThriveProductShop.models;

namespace ThriveProductShop.Services
{

    public class DataService
    {
        private readonly ProductRepository _productRepository;

        public DataService()
        {
            _productRepository = new ProductRepository();
        }
        
        public int CreateProduct(ProductGroup product)
        {
            return _productRepository.Create(product);
        }

        public List<ProductList> GetProducts()
        {
            return _productRepository.GetAll();
        }
        
        public IEnumerable<ProductGroup> GetProductsGroup()
        {
            return _productRepository.GetAllGroups();
        }
        
        public ProductList GetProductById(long id)
        {
            return _productRepository.GetById(id);
        }

        public bool DeleteProduct(long id)
        {
            var product = _productRepository.GetById(id);
            return _productRepository.Remove(product);
        }
        
        public bool UpdateProduct(ProductGroup product)
        {
            return _productRepository.Update(product);
        }
    }
}

