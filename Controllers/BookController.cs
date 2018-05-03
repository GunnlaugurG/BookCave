using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers {
    public class BookController : Controller
    {
        public IActionResult Details (int? id){
            if(id == null){
                return View("NotFound");
            }

            BookDetails Temp = new BookDetails(){
                        Id = 1,
                        Name = "Book",
                        Author = "Stefán Örn",
                        Description = "Loerm ispmu sdfsaf314234kslfjaslækfdjs",
                        Image = "https://d1w7fb2mkkr3kw.cloudfront.net/assets/images/book/lrg/9780/7303/9780730324218.jpg",
                        Price = 100,
                        Ratings = 76.4,
                        Comments = new List<Comments>{
                            new Comments{
                                Author = "tommi tommson",
                                Description = "fínasta bók",
                                Ratings = 34 
                            }
                        }
                    };

            return View( Temp );
        }
    }
}