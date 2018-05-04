using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers {
    public class BookController : Controller
    { 
        private BookServices _bookService;
        private List<BookListViewModel> books;
        public BookController() {
            _bookService = new BookServices();
        }
        public IActionResult Index() {
            books = _bookService.GetAllBooks();
            return View(books);
        }

        //This Displays the top ten books ordered by rating
        public IActionResult TopTenBooks(int value) {        
            books = _bookService.GetTopTenBooks(value);
            return View(books);
        }
    }
}