namespace BookCave.Data {
    public class CartItem {
        public string cartItemID { get; set; }  
        public Book book { get; set; }
        public int bookQuantity { get; set; }
        public double itemCost { get; set; }
    }
}