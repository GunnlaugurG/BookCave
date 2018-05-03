namespace BookCave.Models.ViewModels
{
    using System.Collections.Generic;
    public class BookListItem
    {
        public int BookId {get; set;}
        public string picture {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}
        public int Rating {get; set;}
        public string Description {get; set;}
        public int Price {get; set;}
    }
}