namespace BookCave.Data.EntityModels
{
    using System.Collections.Generic;
    public class UserAccount
    {
        public string userID {get; set;}
        public string userName {get; set;}
        public string password {get; set;}
        public string favoriteBookId {get; set;}
        public string picture {get; set;}
        public CardInfo cardInfo {get; set;}
        public ShippingInfo shippingInfo {get; set;}
        public List<Order> orderHistory {get; set;}
        public List<BookId> wishList {get; set;}
    }
}