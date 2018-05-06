using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult TopTenBooks(string value)
        {
            if( value == "rating"){
                books = _bookService.GetTopBooks(select.topRating, 10);
            }
            else if( value == "price"){
                books = _bookService.GetTopBooks(select.bottomPrice, 10);
            }
            else if ( value == "name"){
                books = _bookService.GetTopBooks(select.topName, 10);
            }
            return View(books);
        }

        public IActionResult SortByGenre(string genre)
        {
            genre = "Fantasy";
            ViewBag.genre = genre;
            var sortBy = _bookService.GetBooksByGenre(genre);
            return View(sortBy);
        }


        public IActionResult Search(string searchedWord) {
           
            ViewBag.searchedWord = "Results for: " + searchedWord;
            var searchedResults = _bookService.GetSearchedResults(searchedWord);
            if(searchedResults.Count() == 0) {
                ViewBag.searchedWord = "No results found..";
            }
            return View(searchedResults);
        }
    }
}