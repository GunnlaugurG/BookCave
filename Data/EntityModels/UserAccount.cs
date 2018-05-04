namespace BookCave.Data.EntityModels
{
    using System.Collections.Generic;
    public class UserAccount
    {
        public string userID {get; set;}
        public string userName {get; set;}
        public string password {get; set;}
        //public Book favoriteBook {get; set;}
        public string picture {get; set;}
        public CardInfo cardInfo {get; set;}
        public ShippingInfo shippingInfo {get; set;}
        public List<Order> orderHistory {get; set;}
        //public List<Book> wishList {get; set;}
    }
}