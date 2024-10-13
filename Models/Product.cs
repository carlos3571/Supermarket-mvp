using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Models
{
    internal class Product
    {
        [DisplayName("Product Id")]
        public int ProductId { get; set; }

        [DisplayName("Product txtCategoryName")]
        [Required(ErrorMessage = "Product txtCategoryName is required")]
        [StringLength(50, MinimumLength = 3,
        ErrorMessage = "product txtCategoryName must be between 3 and 50 characters")]

        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "product Description is required")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "product Observation must be between 3 and 200 characters")]
        public string Description { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "product Price is required")]
        public decimal Price { get; set; }

        [DisplayName("Category Id")]
        [Required(ErrorMessage = "Category Id is required")]
        public int CategoryId { get; set; }

    }
}
