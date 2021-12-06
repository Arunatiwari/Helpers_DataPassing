using Helpers_DataPassing.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Helpers_DataPassing.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "ConfirmPassword does not match")]
        public string ConfirmPassword { get; set; }

        public string? Address { get; set; }

        [RegularExpression("^[6789]\\d{9}$", ErrorMessage = "Please enter correct mobile no.")]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Please select Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please select City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; }

        [ValidateCheckBox(ErrorMessage = "Please Enter Terms")]
        public bool Term { get; set; }
        
    }

    
}
