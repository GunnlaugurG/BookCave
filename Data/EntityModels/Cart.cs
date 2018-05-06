using System.Collections.Generic;

namespace BookCave.Data.EntityModels{
    public class Cart{
        public string Id { get; set; }
        public int quantityInCart { get; set; }
        public double totalCost { get; set; }
        public string cartForUserId { get; set; }
    }
}