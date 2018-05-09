using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private BookServices _bookService;

        public HomeController()
        {
            _bookService = new BookServices();
        }

        public IActionResult Index()
        {
            /// Vill fá 5 vinsælustu bækurnar og 5 ódýrustu bækurnar
            var retBooks = new List<BookListViewModel>();
            retBooks = _bookService.GetTopBooks("mostPopular",4);
            retBooks.AddRange(_bookService.GetTopBooks("lowPrice", 4));
            return View(retBooks);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}