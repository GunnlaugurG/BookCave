using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email{ get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        [NotMapped]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")] 
        public string ConfirmPassword {get; set;}
    }
}
