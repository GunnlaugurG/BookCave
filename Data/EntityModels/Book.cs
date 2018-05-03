namespace BookCave.Data.EntityModels{
    public class Book {
         public string bookID { get; set; }

         public string title { get; set; }

         public string genre { get; set; }

         public Author author { get; set; }
         
         public double cost { get; set; }

    }
}