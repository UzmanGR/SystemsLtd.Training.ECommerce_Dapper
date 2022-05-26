using Microsoft.Extensions.Logging;
using SystemsLtd.Training.ECommerce.Model;
using SystemsLtd.Training.ECommerce.Repository;

namespace SystemsLtd.Training.ECommerce.Service.Interface
{
    public interface IProductService
    {
        #region Public Methods
        Task<IEnumerable<Product>> GetProducts();
        IEnumerable<Product> GetAllProducts(Product product);
        Product GetProduct(int id);
        Task<int> AddProduct(Product product);
        bool UpdateProduct(Product product);

        bool DeleteProduct(Product product);
        #endregion
    }
}