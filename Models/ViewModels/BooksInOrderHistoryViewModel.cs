using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels {
    public class BooksInOrderHistoryViewModel {
        public List<DisplayCartItemViewModel> listOfBooks {get; set;}
        public string address { get; set; }
        public string country { get; set; }
        public string city {get; set;}
        public string zipCode {get; set;}
        public double totalCost { get; set; }
        public int quantity {get; set;}
    }
}