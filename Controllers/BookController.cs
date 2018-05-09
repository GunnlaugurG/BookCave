using BookCave.Models;
using BookCave.Models.InputModel;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        private AccountServices _accountServices = new AccountServices();

        private BookServices _bookService;
        private List<BookListViewModel> books;

        public BookController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
            books = _bookService.GetTopBooks("rating",10);
            return View(books);
        }

        [HttpGet]
        public IActionResult SortBy(string value)
        {
            books = _bookService.SortBy(value);
            return Json(books);
        }

        public IActionResult SortByGenre(string genre)
        {
            if (genre == null)
            {
                return View("PageNotFound");
            }
            ViewBag.genre = genre;
            var sortBy = _bookService.GetBooksByGenre(genre);
            return View(sortBy);
        }

        public IActionResult Details(int id)
        {
            var bookDetails = _bookService.GetBookByID(id);
            if (bookDetails == null)
            {
                return View("BookNotFound");
            }
            return View(bookDetails);
        }

        public async Task<IActionResult> FavoriteBook( int bookId){
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
             if (userId == null) {
                    return Json("RedirectToLogin");
                }
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> review(ReviewInputModel input) {
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
            _bookService.SetBookReview( input, userId );
            return Ok();
        }
        public IActionResult Search(string searchedWord)
        {
            if (searchedWord == null)
            {
                searchedWord = "...";
            }
            ViewBag.searchedWord = "Results for: " + searchedWord;
            var searchedResults = _bookService.GetSearchedResults(searchedWord);
            if (searchedResults.Count() == 0)
            {
                ViewBag.searchedWord = "No results found..";
            }
            return View(searchedResults);
        }
    }
}