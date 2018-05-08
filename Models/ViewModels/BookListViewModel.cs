using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public Author author { get; set; }
        public string image { get; set; }
        public double cost { get; set; }
        public double rating { get; set; }
    }
}