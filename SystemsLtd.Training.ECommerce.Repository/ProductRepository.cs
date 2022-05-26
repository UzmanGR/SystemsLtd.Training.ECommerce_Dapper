using Microsoft.Extensions.Logging;
using SystemsLtd.Training.ECommerce.Repository.Interface;
using SystemsLtd.Training.ECommerce.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;

namespace SystemsLtd.Training.ECommerce.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region Properties
        private readonly ILogger<ProductRepository> Logger;
        private readonly ECommerceDBContext ECommerceDBContext;
        private readonly string _connectionString;
        private static List<Product> Products = new List<Product>()
            {
                new Product()
                {
                    ProductId =1,
                    ProductName="Dell Laptop",
                    ProductDescription = "Dell Laptop E6410",
                    PurchasePrice = 1000.50m,
                    SalesPrice = 1200.00m,
                    Active = true,
                    CategoryId = 1
                },
                new Product()
                {
                    ProductId =2,
                    ProductName="HP Laptop",
                    ProductDescription = "HP Laptop E6410",
                    PurchasePrice = 1000.50m,
                    SalesPrice = 1200.00m,
                    Active = true,
                    CategoryId = 1
                },
                new Product()
                {
                    ProductId =3,
                    ProductName="Lenovo Laptop",
                    ProductDescription = "Lenovo Laptop E6410",
                    PurchasePrice = 1000.50m,
                    SalesPrice = 1200.00m,
                    Active = true,
                    CategoryId = 1
                }
            };
        #endregion

        #region Constractor
        public ProductRepository(ILogger<ProductRepository> logger, ECommerceDBContext eCommerceDBContext, IConfiguration configuration)
        {
            this.Logger = logger;
            this.ECommerceDBContext = eCommerceDBContext;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        #endregion

        #region Public Methods
        public async Task<IEnumerable<Product>> GetProducts()
        {
            var sqlQuery = "Select * from Product";
            using(var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Product>(sqlQuery);
            }
           // return this.ECommerceDBContext.Products.ToList();
        }
        public Product GetProduct(int id)
        {
            var sqlQuery = "Select * from Product WHERE ProductId = @Itemid";
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.QueryFirstOrDefault<Product>(sqlQuery, new { Itemid = id});
            }
            // return this.ECommerceDBContext.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public IEnumerable<Product> GetAllProducts(Product product)
        {
            var products = this.ECommerceDBContext.Products.ToList();

            if(product!=null)
            {
                if(!string.IsNullOrWhiteSpace(product.ProductName))
                {
                    products = products.Where(x => x.ProductName.Contains(product.ProductName, StringComparison.CurrentCultureIgnoreCase)).ToList();
                }

                if (product.CategoryId > 0)
                {
                    products = products.Where(x => x.CategoryId == product.CategoryId).ToList();
                }

                products = products.Where(x => x.Active == product.Active).ToList();
            }

            return products;
        }

        public async Task<int> AddProduct(Product product)
        {
            var sqlQuery = "INSERT INTO Product(CategoryId,ProductName, ProductDescription, SalesPrice, PurchasePrice, Active) VALUES (@CategoryId,@ProductName, @ProductDescription, @SalesPrice, @PurchasePrice, @Active)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    product.CategoryId,
                    product.ProductName,
                    product.ProductDescription,
                    product.SalesPrice,
                    product.PurchasePrice,
                    product.Active
                });

                return product.ProductId;
            }
        }

        public bool UpdateProduct(Product product)
        {
            var existingProduct = this.ECommerceDBContext.Products.FirstOrDefault(x=> x.ProductId == product.ProductId);

            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductDescription = product.ProductDescription;    
                existingProduct.PurchasePrice = product.PurchasePrice;  
                existingProduct.SalesPrice = product.SalesPrice;
                existingProduct.Active = product.Active;  
                existingProduct.CategoryId = product.CategoryId;

                var result = this.ECommerceDBContext.SaveChanges();

                return result > 0;
            }
            else
            {
                return false;
            }
        }


        public bool DeleteProduct(Product product)
        {
            var existingProduct = this.ECommerceDBContext.Products.Remove(product);

            var result = this.ECommerceDBContext.SaveChanges();

            return result > 0;
        }
        #endregion
    }
}
