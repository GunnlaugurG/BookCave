using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels {
    public class OrderHistoryViewModel {
        public List<BooksInOrderHistoryViewModel> orderList {get; set;}
    }
}