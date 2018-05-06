using BookCave.Data.EntityModels;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels {
    public class AuthorDetailsViewModel {
         public string image { get; set; }
         public string authorName { get; set; }
         public List<Book> writtenBooks { get; set; }
    }
}