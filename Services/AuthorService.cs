using BookCave.Models.ViewModels;
using BookCave.Repositories;
using System.Collections.Generic;

namespace BookCave.Services
{
    public class AuthorService
    {
        private AuthorRepo _authorRepo;

        public AuthorService()
        {
            _authorRepo = new AuthorRepo();
        }

        public AuthorDetailsViewModel GetAuthorById(string id)
        {
            return _authorRepo.GetAuthorById(id);
        }

        public List<AuthorListViewModel> GetAllAuthors()
        {
            return _authorRepo.GetAllAuthors();
        }
    }
}