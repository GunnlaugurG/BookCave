using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services {
    public class BookServices {

        private BookRepo _bookRepo;
        public BookServices(){
            _bookRepo = new BookRepo();
        }
        public List<BookListViewModel> GetAllBooks(){
            
            return _bookRepo.GetAllBooks();
        }
        public List<BookListViewModel> GetTopTenBooks(int value) {
            
            if(value == 1) {
            var topRating = (from b in _bookRepo.GetAllBooks()
                           orderby b.rating descending
                           select b).Take(10).ToList();
                           return topRating;
            }
            if(value == 0) {
            var topPrice = (from b in _bookRepo.GetAllBooks()
                           orderby b.cost descending
                           select b).Take(10).ToList();
                           return topPrice;
            }
            if(value == 3) {
            var topName = (from b in _bookRepo.GetAllBooks()
                           orderby b.title
                           select b).Take(10).ToList();
                           return topName;
            }
            else {
                var topBooks = (from b in _bookRepo.GetAllBooks()
                           orderby b.rating descending
                           select b).Take(10).ToList();
                           return topBooks;
                }
            }
        }
    }
