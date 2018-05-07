using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels {
    public class BookDetailsViewModel {
        public int id { get; set; }
        public string name { get; set; }
        public Author author { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public double price{ get; set; }
        public double rating { get; set; } 
        public List<CommentsViewModel> comments { get; set; }
    }
}