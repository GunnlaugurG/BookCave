namespace BookCave.Data.EntityModels{
    public class Book {
         public int Id { get; set; }
         public int authorId { get; set; }
         public string title { get; set; }
         public string genre { get; set; }
         public double cost { get; set; }
         public int rating { get; set; }
         public string image { get; set; }

    }
}