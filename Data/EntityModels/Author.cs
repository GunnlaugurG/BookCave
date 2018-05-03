using System.Collections.Generic;

namespace BookCave.Data {

    public class Author {
         public string authorID { get; set; }

         public string authorName { get; set; }

         public int authorAge { get; set; }
         
         public List<Book> writtenBooks { get; set; }
    }
}