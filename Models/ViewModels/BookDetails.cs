using System.Collections.Generic;
using BookCave.Models.ViewModels;

namespace BookCave.Models.ViewModels {
    public class BookDetails {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price{ get; set; }
        public double Ratings{ get; set; } 
        public List<Comments> Comments { get; set; }
    }
}