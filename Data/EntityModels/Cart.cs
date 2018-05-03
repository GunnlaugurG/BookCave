using System.Collections.Generic;

namespace BookCave.Data.EntityModels{
    public class Cart{
        public string cartID { get; set; }
        public List<CartItem> itemsInCart { get; set; }
        public int quantityInCart { get; set; }
        public double totalCost { get; set; }
        
    }
}