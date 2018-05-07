using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class AccountDetailsViewModel
    {
        public string userName { get; set; }
        public byte[] picture { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string zipCode { get; set; }
        public string favoriteBookName {get; set;}
        public string cardNumber {get; set;}
        public string cardholderName {get; set;}
    }
}
