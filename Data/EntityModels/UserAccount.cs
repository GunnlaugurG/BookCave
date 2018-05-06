namespace BookCave.Data.EntityModels
{
    using System.Collections.Generic;
    public class UserAccount
    {
        public string Id {get; set;}
        public string aspUserId { get; set;}
        public string userName {get; set;}
        public string password {get; set;}
        public Book favoriteBook {get; set;}
        public string picture {get; set;}
        public CardInfo cardInfo {get; set;}
        public ShippingInfo shippingInfo {get; set;}
    }
}