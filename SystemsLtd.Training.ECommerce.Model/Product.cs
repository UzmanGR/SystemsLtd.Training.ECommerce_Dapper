using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemsLtd.Training.ECommerce.Model
{
    public class Product
    {
        #region Properties
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalesPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal PurchasePrice { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Constractor
        public Product()
        {
        }
        #endregion

        #region Public Methods
        #endregion
    }
}
