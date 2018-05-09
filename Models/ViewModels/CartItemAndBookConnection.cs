using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class CartItemAndBookConnection
    {
        public int bookId { get; set; }
        public int quantity {get; set;}
    }
}