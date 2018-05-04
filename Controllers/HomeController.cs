using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            /// Vill fá 5 vinsælustu bækurnar og 5 ódýrustu bækurnar
            var tempBookList = new List<BookListViewModel>();
            for(int i = 0; i < 10; i++){
                tempBookList.Add( new BookListViewModel{ 
                    Id = i,
                    title = "Sagan um bók" + i,
                    image = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/7303/9780730324218.jpg",
                    cost = 1000,
                    rating = 56.4
                });
            }

            return View( tempBookList );
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
