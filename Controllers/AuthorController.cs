using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Models.ViewModels;
using BookCave.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookCave.Controllers {
    

    public class AuthorController : Controller {
        private AuthorService _authorService;

        public AuthorController() {
            _authorService = new AuthorService();
        }
        public IActionResult Index() {
            var authors = _authorService.GetAllAuthors();
            return View(authors);
        }

        public IActionResult Details(string id) {
            var authorDetails = _authorService.GetAuthorById(id);
            return View(authorDetails);   
        }
    }
}