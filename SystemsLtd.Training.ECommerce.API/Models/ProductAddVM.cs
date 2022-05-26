using System.ComponentModel.DataAnnotations;

namespace SystemsLtd.Training.ECommerce.API.Models
{
    public class ProductAddVM
    {
        #region Properties
        public int CategoryId { get; set; }

        [Required]
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public bool Active { get; set; }
        #endregion
    }
}
