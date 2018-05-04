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

    }

}