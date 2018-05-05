using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {

        private BookServices _bookService;

        public HomeController(){
            _bookService = new BookServices();
        }
        public IActionResult Index()
        {
            
            /// Vill fá 5 vinsælustu bækurnar og 5 ódýrustu bækurnar
            var retBooks = new List<BookListViewModel>();
/*
            retBooks = _bookService.GetTopBooks(select.topRating, 5);
            retBooks.AddRange( _bookService.GetTopBooks(select.bottomPrice, 5));
*/
            return View( retBooks );
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
