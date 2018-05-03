namespace BookCave.Data {
    public class Book {
         public string bookID { get; set; }

         public string title { get; set; }

         public string genre { get; set; }

         public Author Author { get; set; }
         
         public double cost { get; set; }

    }
}