using System.Collections.Generic;
namespace BookCave.Data.EntityModels {
    public class Order {
        public string orderID { get; set; }
        public Cart itemsBought { get; set; }
        public ShippingInfo orderShippingInfo { get; set; }
    }
}