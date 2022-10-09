using WebApplication1.Entities;
using WebApplication1.Repository;

namespace WebApplication1.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetEntityList();
        }

        public Product GetProduct(int productId)
        {
            return _productRepository.GetEntity(productId);
        }
    }
}
