using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket_mvp.Models
{
    internal class Providers
    {
        [DisplayName("Provider Id")]
        public int ProviderId { get; set; }

        [DisplayName("Provider Name")]
        [Required(ErrorMessage = "Provider Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Provider Name must be between 3 and 100 characters")]
        public string Name { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 200 characters")]
        public string Address { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

    }
}
