using BookCave.Data;
using BookCave.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Repositories
{
    public class AuthorRepo
    {
        private DataContext _db;

        public AuthorRepo()
        {
            _db = new DataContext();
        }

        //Displays the list of actors ordered by the highest rated book of theirs.
        public List<AuthorListViewModel> GetAllAuthors()
        {
            var authors = (from a in _db.authors
                           orderby a.authorName
                           select new AuthorListViewModel {
                               Id = a.Id,
                               authorName = a.authorName,
                           }).ToList();
            var allBooks = ( from b in _db.books
                            select b).ToList();

            for(int i = 0; i < authors.Count; i++) {
                authors[i].mostPopularBook = (from b in _db.books
                            where b.keyAuthorId == authors[i].Id
                            orderby b.copiesSold descending
                            select new BookListItemViewModel{
                                Id = b.Id,
                                title = b.title
                            }).First();
            }
            return authors;
        }

        //Finds the author with the given ID and returns
        public AuthorDetailsViewModel GetAuthorById(string id)
        {
            var writtenBooks = (from b in _db.books
                                join a in _db.authors on b.keyAuthorId equals a.Id
                                where a.Id == id
                                select new BookListItemViewModel{
                                    Id = b.Id,
                                    title = b.title
                                }).ToList();

            var authorId = (from a in _db.authors
                            where a.Id == id
                            select new AuthorDetailsViewModel
                            {
                                authorName = a.authorName,
                                image = a.image,
                                writtenBooks = writtenBooks,
                                authorDescription = a.authorDescription
                            }).SingleOrDefault();
            return authorId;
        }
        public AuthorListViewModel GetAuthorListViewModelById(string id){
           
            var authorId = (from a in _db.authors
                            where a.Id == id
                            select new AuthorListViewModel
                            {
                                Id = a.Id,
                                authorName = a.authorName
                            }).SingleOrDefault();
            return authorId;
        }
    }
}