namespace BookCave.Data.EntityModels {
    public class CartItem {
        public string Id { get; set; }  
        public int bookForCartItem { get; set; }
        public int bookQuantity { get; set; }
        public double itemCost { get; set; }
        public string keyCartId { get; set; }
    }
}