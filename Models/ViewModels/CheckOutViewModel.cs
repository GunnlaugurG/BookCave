using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class CheckOutViewModel
    {
        public string address { get; set; }
        public string zip {get; set;}
        public string country { get; set; }
        public string city {get; set;}
        public string cardHolderName { get; set; }
        public string cardNumber { get; set; }
        public List<BookInCartListViewModel> booksList { get; set; }
        public double totalCost {get; set;}
    }
}