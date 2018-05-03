namespace BookCave.Models.ViewModels {
    public class BookListViewModel {
        public int Id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int authorId { get; set; }
        public double cost { get; set; }
        public double rating { get; set; }
    }
}