using System.Collections.Generic;

namespace BookCave.Data.EntityModels{
    public class WishList{
        public string Id { get; set; }
        public string aspUserforWishList { get; set; }
        public int bookForWishListId { get; set; }
    }
}