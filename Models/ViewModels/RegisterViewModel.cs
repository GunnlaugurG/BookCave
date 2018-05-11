using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookCave.Models.ViewModels {
    public class RegisterViewModel {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password must contain 1 special character, 1 upper case character and must be 10 characters")]
        [RegularExpression("^(?=.*\\d)(?=.*[#$@!%&*?/()=?*:.;,<>|+'°¨])[A-Za-z\\d#$@!%&*?/()=?*:.;,<>|+'°¨]{10,}$", ErrorMessage = "Password must contain 1 spceial character, 1 upper case character and must be 10 characters")]
        public string Password { get; set; }

        [NotMapped]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }
}