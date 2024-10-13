using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Models
{
    internal class Categories
    {
        [DisplayName("CategoryId")]
        public int CategoryId { get; set; }

        [DisplayName("Categories txtCategoryName")]
        [Required(ErrorMessage = "El nombre de la Categoria is  required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la Categoria must be between 3 and 50 characters")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Categories Description is required")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "Categories Observation must be between 3 and 200 characters")]
        public string Description { get; set; }

    }
}
