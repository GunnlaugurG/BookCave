using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;
        public BookRepo() {
            _db = new DataContext();
        }
        public List<Book> GetAllBooks() {
           var books = (from b in _db.books 
                        select b).ToList();
            return books;
        }
        public void UpdateABook( Book book ){
            // hér þarf að updeita book
        }
    }
}
