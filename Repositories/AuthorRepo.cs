using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories {
    public class AuthorRepo {

        private DataContext _db;
        public AuthorRepo() {
            _db = new DataContext();
        }
        public List<AuthorListViewModel> GetAllAuthors() {
            var authors = (from a in _db.authors
                           select new AuthorListViewModel {
                               Id = a.Id,
                               authorName = a.authorName
                           }).ToList();
            return authors;
        }
        public AuthorDetailsViewModel GetAuthorById(string id) {
            var writtenBooks = (from b in _db.books
                          join a in _db.authors on b.keyAuthorId equals a.Id
                          where a.Id == id
                          select b).ToList();

            var authorId = (from a in _db.authors
                            where a.Id == id
                            select new AuthorDetailsViewModel{
                                authorName = a.authorName,
                                image = a.image,
                                writtenBooks = writtenBooks
                            }).SingleOrDefault();
            return authorId;
        }
    }
}