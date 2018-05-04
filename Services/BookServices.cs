using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

 public enum select{
    topRating,
    topPrice,
    topName,
    bottomPrice
};

namespace BookCave.Services {
    public class BookServices {

        private BookRepo _bookRepo;
        public BookServices(){
            _bookRepo = new BookRepo();
        }
        public List<BookListViewModel> GetAllBooks(){
            
            return _bookRepo.GetAllBooks();
        }
        public BookDetailsViewModel GetBookByID(int id){
        
            var bookByID = ( from b in _bookRepo.GetAllBooks()
                            where b.Id == id 
                            select b).FirstOrDefault();
            /// book repo þarf að skila entity klasa...
            return null;
        }
        public List<BookListViewModel> GetTopBooks( select value, int count) {
            
            if( value == select.topRating) {
            var topRating = (from b in _bookRepo.GetAllBooks()
                           orderby b.rating descending
                           select b).Take(count).ToList();
                           return topRating;
            }
            if(value == select.topPrice) {
            var topPrice = (from b in _bookRepo.GetAllBooks()
                           orderby b.cost descending
                           select b).Take(count).ToList();
                           return topPrice;
            }
            if(value == select.topName) {
            var topName = (from b in _bookRepo.GetAllBooks()
                           orderby b.title
                           select b).Take(count).ToList();
                           return topName;
            }
            if(value == select.bottomPrice){
                var bottomPrice = (from b in _bookRepo.GetAllBooks()
                orderby b.cost ascending
                select b).Take(count).ToList();
                return bottomPrice;
            } 
            else {
                var topBooks = (from b in _bookRepo.GetAllBooks()
                           orderby b.rating descending
                           select b).Take(count).ToList();
                           return topBooks;
                }
            }
        }
    }
