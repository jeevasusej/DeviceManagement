using System.ComponentModel.DataAnnotations;

namespace DeviceManagement.Api.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(32, MinimumLength = 5, ErrorMessage = "Please provide characters between 5 and 32")]
        [RegularExpression("^[-_A-Za-z0-9]*$", ErrorMessage = "Please provide characters and number")]
        public string Username { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "Please provide characters between 5 and 255")]
        [RegularExpression("^[ -_A-Za-z0-9]*$", ErrorMessage = "Please provide characters and number")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        //^                         Start anchor
        //(?=.*[A-Z].*[A-Z])        Ensure string has two uppercase letters.
        //(?=.*[!@#$&*])            Ensure string has one special case letter.
        //(?=.*[0-9].*[0-9])        Ensure string has two digits.
        //(?=.*[a-z].*[a-z].*[a-z]) Ensure string has three lowercase letters.
        //.{8}
        //    Ensure string is of length 8.
        //$                         End anchor.
        [Required]
        [RegularExpression("^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8}$"
            , ErrorMessage = "Ensure 2 upper case, 1 special character, 2 digits, 3 lower case and 8 character length")]
        public string Password { get; set; }
    }
}