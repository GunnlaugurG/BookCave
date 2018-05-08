namespace BookCave.Data.EntityModels
{
    public class UserAccount
    {
        public string Id { get; set; }
        public string aspUserId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int favoriteBookForUserId { get; set; }
        public string picture { get; set; }
        public string cardInfoForUserId { get; set; }
        public string shippingInfoForUserId { get; set; }
    }
}