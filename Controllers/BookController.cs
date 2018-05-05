using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Models.InputModel;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookServices _bookService;
        private List<BookListViewModel> books;

        public BookController()
        {
            _bookService = new BookServices();
        }

        public IActionResult Index()
        {
            books = _bookService.GetAllBooks();
            return View(books);
        }

        //This Displays the top ten books ordered by rating
        [HttpGet]
        public IActionResult TopTenBooks(int value)
        {
            books = _bookService.GetTopBooks(value, 10);
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var bookDetails = _bookService.GetBookByID(id);
            return View(bookDetails);
        }

        public IActionResult SortByGenre(string genre)
        {
            genre = "Fantasy";
            ViewBag.genre = genre;
            var sortBy = _bookService.GetBooksByGenre(genre);
            return View(sortBy);
        }
        public IActionResult review( ReviewInputModel input ){
            
            return View();
        }
    }
}