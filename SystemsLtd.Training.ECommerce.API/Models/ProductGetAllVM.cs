using System.ComponentModel.DataAnnotations;

namespace SystemsLtd.Training.ECommerce.API.Models
{
    public class ProductGetAllVM
    {
        #region Properties
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public bool Active { get; set; }
        #endregion
    }
}
