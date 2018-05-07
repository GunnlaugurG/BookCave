using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services {
    public class AuthorService {

        private AuthorRepo _authorRepo;
        public AuthorService() {
            _authorRepo = new AuthorRepo();
        }
        public AuthorDetailsViewModel GetAuthorById(string id) {
            
            return _authorRepo.GetAuthorById(id);
        }

        public List<AuthorListViewModel> GetAllAuthors() {
            
            return _authorRepo.GetAllAuthors();
        }
    }
}