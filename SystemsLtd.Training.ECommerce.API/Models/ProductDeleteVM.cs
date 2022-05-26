using System.ComponentModel.DataAnnotations;

namespace SystemsLtd.Training.ECommerce.API.Models
{
    public class ProductDeleteVM
    {
        #region Properties
        [Required]
        [Range(1, int.MaxValue)]
        public int ProductId { get; set; }
        #endregion
    }
}
