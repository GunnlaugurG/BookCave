using System.Collections.Generic;

namespace BookCave.Models.ViewModels {
    public class DisplayCartViewModel {
        public List<BookInCartListViewModel> booksList { get; set; }
        public double totalCost {get; set;}
    }
}