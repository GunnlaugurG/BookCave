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
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        //This Displays the top ten books ordered by rating
        [HttpGet]
        public IActionResult TopTenBooks()
        {
                books = _bookService.GetTopBooks(select.topRating, 10);

            return View(books);
        }
        [HttpPost]
        public IActionResult SortBy( string value ){
            if( value == "rating"){
                books = _bookService.GetTopBooks(select.topRating, 10);
            }
            else if( value == "lowPrice"){
                books = _bookService.GetTopBooks(select.bottomPrice, 10);
            }
            else if( value == "highPrice"){
                books = _bookService.GetTopBooks(select.topPrice, 10);
            }
            else if ( value == "name"){
                books = _bookService.GetTopBooks(select.topName, 10);
            }
            else{
               books = _bookService.GetTopBooks(select.topRating, 10); 
            }
            return Json(books);
        }

        public IActionResult SortByGenre(string genre)
        {
            if(genre == null) {
                return View("PageNotFound");
            }
            ViewBag.genre = genre;
            var sortBy = _bookService.GetBooksByGenre(genre);
            return View(sortBy);
        }
        public IActionResult Details(int id)
        {
            var bookDetails = _bookService.GetBookByID(id);
            if(bookDetails == null) {
                return View("BookNotFound");
            }
            return View(bookDetails);
        }
        [HttpGet]
        public IActionResult review( int id ){

            var quickAndDirty = new ReviewInputModel{ bookId = id };
            return View( quickAndDirty );
        }
        [HttpPost]
        public IActionResult review( ReviewInputModel input ){
            
            //_bookService.SetBookReview( input );
            return RedirectToAction("Index");
        }

        public IActionResult Search(string searchedWord) {
            
            if(searchedWord == null) {
                searchedWord = "";
            }
            ViewBag.searchedWord = "Results for: " + searchedWord;
            var searchedResults = _bookService.GetSearchedResults(searchedWord);
            if(searchedResults.Count() == 0) {
                ViewBag.searchedWord = "No results found..";
            }
            return View(searchedResults);
        }
    }
}