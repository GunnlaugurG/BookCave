using System.Collections.Generic;
namespace BookCave.Data.EntityModels {
    public class Order {
        public string Id { get; set; }
        public string OrderForCartId { get; set; }
        public string aspForCartId { get; set; }
    }
}