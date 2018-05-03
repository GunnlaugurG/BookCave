using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Models.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress]
        public string Email{ get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
