using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;
        public BookRepo() {
            _db = new DataContext();
        }
        public List<BookListViewModel> GetAllBooks() {
           var books = (from b in _db.books
                        select new BookListViewModel {
                            title = b.title,
                            author = b.author,
                            rating = b.rating,
                            image = b.image,
                            cost = b.cost,
                        }).ToList();
            return books;
        }
    }
}
