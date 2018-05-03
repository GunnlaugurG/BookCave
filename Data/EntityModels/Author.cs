using System.Collections.Generic;

namespace BookCave.Data.EntityModels {

    public class Author {
         public string Id { get; set; }
         public int authorId { get; set; }
         public string authorName { get; set; }
         public List<Book> writtenBooks { get; set; }
    }
}