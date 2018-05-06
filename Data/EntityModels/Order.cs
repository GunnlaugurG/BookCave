using System.Collections.Generic;
namespace BookCave.Data.EntityModels {
    public class Order {
        public string Id { get; set; }
        public Cart itemsBought { get; set; }
        public string cartUserId { get; set; }
        public ShippingInfo orderShippingInfo { get; set; }
    }
}