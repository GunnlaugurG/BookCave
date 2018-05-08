namespace BookCave.Models.ViewModels
{
    public class BookListItem
    {
        public int BookId { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}