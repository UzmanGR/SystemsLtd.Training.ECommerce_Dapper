using Microsoft.AspNetCore.Mvc;
using SystemsLtd.Training.ECommerce.API.Models;
using SystemsLtd.Training.ECommerce.Model;
using SystemsLtd.Training.ECommerce.Service;
using SystemsLtd.Training.ECommerce.Service.Interface;

namespace SystemsLtd.Training.ECommerce.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Route("[controller]")]
    public class ProductController : ControllerBase
    {
        #region Properties
        private readonly ILogger<ProductController> Logger;
        private readonly IProductService ProductService;
        #endregion

        #region Constractor
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            this.Logger = logger;
            this.ProductService = productService;
        }
        #endregion


        #region Public Methods

        [HttpGet(Name = "GetProducts")]
        public Task<IEnumerable<Product>> GetProducts()
        {
            return this.ProductService.GetProducts();
        }

        [HttpGet(Name = "GetAllProducts")]
        public IEnumerable<ProductGetAllResponseVM> GetAllProducts([FromQuery] ProductGetAllVM productVM)
        {
            var product = new Product
            {
                CategoryId = productVM.CategoryId,
                ProductName = productVM.ProductName,
                Active = productVM.Active
            };
            var result = this.ProductService.GetAllProducts(product);

            var resultVM = new List<ProductGetAllResponseVM>();
            if (result!=null)
            {
                foreach (var prod in result)
                {
                    resultVM.Add(new ProductGetAllResponseVM
                    {
                        ProductId = prod.ProductId,
                        ProductName = prod.ProductName,
                        ProductDescription = prod.ProductDescription,
                        SalesPrice = prod.SalesPrice,
                        Active = prod.Active
                    });
                }
            }

            return resultVM;
        }


        [HttpGet(Name = "GetProduct")]
        public Product GetProduct(int id)
        {
            return this.ProductService.GetProduct(id);
        }


        [HttpPost(Name = "AddProduct")]
        public Task<int> AddProduct([FromBody] ProductAddVM productVM)
        {
            var product = new Product
            {
                CategoryId = productVM.CategoryId,
                ProductName = productVM.ProductName,
                ProductDescription = productVM.ProductDescription,
                SalesPrice = productVM.SalesPrice,
                PurchasePrice = productVM.PurchasePrice,
                Active = productVM.Active
            };
            return this.ProductService.AddProduct(product);
        }


        [HttpPut(Name = "UpdateProduct")]
        public bool UpdateProduct([FromBody] ProductUpdateVM productVM)
        {
            var product = new Product
            {
                ProductId = productVM.ProductId,
                CategoryId = productVM.CategoryId,
                ProductName = productVM.ProductName,
                ProductDescription = productVM.ProductDescription,
                SalesPrice = productVM.SalesPrice,
                PurchasePrice = productVM.PurchasePrice,
                Active = productVM.Active
            };

            return this.ProductService.UpdateProduct(product);
        }


        [HttpDelete(Name = "DeleteProduct")]
        public bool DeleteProduct(ProductDeleteVM productVM)
        {
            var product = new Product
            {
                ProductId = productVM.ProductId
            };

            return this.ProductService.DeleteProduct(product);
        }
        #endregion

    }
}