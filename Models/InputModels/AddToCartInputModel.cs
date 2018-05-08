using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModel
{
    public class AddToCartInputModel
    {
        public int bookId { get; set; }
        public string UserId { get; set; }
        public int quantity { get; set; }
    }
}