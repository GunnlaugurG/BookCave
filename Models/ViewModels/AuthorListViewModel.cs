using BookCave.Data.EntityModels;
using System.Collections.Generic;

namespace BookCave.Models.ViewModels {
    public class AuthorListViewModel {
        public string Id { get; set; }
        public string authorName { get; set; }
        public BookListItemViewModel mostPopularBook { get; set; }
    }
}