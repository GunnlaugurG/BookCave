namespace BookCave.Data.EntityModels
{
    public class Order
    {
        public string Id { get; set; }
        public string aspForCartId { get; set; }
        public string address {get; set;}
        public string city { get; set; }
        public string country { get; set; }
        public string zipCode {get; set;}
        public double totalCost {get; set;}
    }
}