using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class BookInCartListViewModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public double cost { get; set; }
        public string image {get; set;}
    }
}