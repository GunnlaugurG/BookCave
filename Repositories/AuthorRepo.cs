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
        //Displays the list of actors ordered by the highest rated book of theirs.
        public List<AuthorListViewModel> GetAllAuthors() {
           
            var authors = (from a in _db.authors
                           join b in _db.books on a.authorName equals b.author
                           orderby b.rating descending
                           select new AuthorListViewModel {
                               Id = a.Id,
                               authorName = a.authorName,
                               mostPopularBook = b
                           }).ToList();
            return authors;
        }
        //Finds the author with the given ID and returns
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