using Microsoft.Extensions.Logging;
using SystemsLtd.Training.ECommerce.Model;
using SystemsLtd.Training.ECommerce.Repository;
using SystemsLtd.Training.ECommerce.Service.Interface;
using SystemsLtd.Training.ECommerce.Repository.Interface;

namespace SystemsLtd.Training.ECommerce.Service
{
    public class ProductService : IProductService
    {
        #region Properties
        private readonly ILogger<ProductService> Logger;
        private readonly IProductRepository ProductRepository;
        #endregion

        #region Constractor
        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            Logger = logger;
            this.ProductRepository = productRepository;
        }
        #endregion


        #region Public Methods
        public Task<IEnumerable<Product>> GetProducts()
        {
            return this.ProductRepository.GetProducts();

        }
        public IEnumerable<Product> GetAllProducts(Product product)
        {
            return this.ProductRepository.GetAllProducts(product);

        }

        public Product GetProduct(int id)
        {
            return this.ProductRepository.GetProduct(id);
        }

        public Task<int> AddProduct(Product product)
        {
            return this.ProductRepository.AddProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return this.ProductRepository.UpdateProduct(product);
        }
        public bool DeleteProduct(Product product)
        {
            return this.ProductRepository.DeleteProduct(product);
        }
        #endregion
    }
}