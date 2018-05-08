using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;
        private ReviewRepo _reviewRepo;

        public BookRepo()
        {
            _reviewRepo = new ReviewRepo();
            _db = new DataContext();
        }


        public string getUserName( string userId){
            var UserName = (from a in _db.userAccounts
                        where a.aspUserId == userId
                        select a.userName).FirstOrDefault();
            return UserName;
        }
        public List<BookListViewModel> GetAllBooks()
        {
            var books = (from b in _db.books
                         join a in _db.authors on b.keyAuthorId equals a.Id
                         orderby b.title
                         select new BookListViewModel
                         {
                             id = b.Id,
                             title = b.title,
                             author = a,
                             rating = b.rating,
                             image = b.image,
                             cost = b.cost

                         }).ToList();
            return books;
        }

        public BookDetailsViewModel GetBookByID(int id)
        {
            var bookByID = (from b in _db.books
                            where b.Id == id
                            join a in _db.authors on b.keyAuthorId equals a.Id
                            select new BookDetailsViewModel
                            {
                                id = b.Id,
                                name = b.title,
                                author = a,
                                description = b.description,
                                image = b.image,
                                price = b.cost,
                                rating = b.rating,
                                comments = _reviewRepo.GetReviewViewModelByBookId(id)
                            }).SingleOrDefault();
            return bookByID;
        }
        public Book getBookEntityModel(int id ){
            var bookByID = (from b in _db.books
                            where b.Id == id
                            select b).SingleOrDefault();
            return bookByID;
        }
        public List<BookListViewModel> GetBooksByGenre(string genre)
        {
            // Flokkar bækur eftir tegund fyrir "Flokka eftir tegund" dropdown listann í navbar
            var sortBy = (from b in _db.books
                          where b.genre.ToLower().Contains(genre.ToLower())
                          join a in _db.authors on b.author equals a.authorName
                          select new BookListViewModel
                          {
                              id = b.Id,
                              title = b.title,
                              author = a,
                              rating = b.rating,
                              image = b.image,
                              cost = b.cost
                          }).ToList();

            return sortBy;
        }

        public List<BookListViewModel> SortBy(string option)
        {
            if (option == "rating")
            {
                var topRating = (from b in _db.books
                                 orderby b.rating descending
                                 join a in _db.authors on b.author equals a.authorName
                                 select new BookListViewModel
                                 {
                                     id = b.Id,
                                     title = b.title,
                                     author = a,
                                     rating = b.rating,
                                     image = b.image,
                                     cost = b.cost
                                 }).ToList();
                return topRating;
            }
            if (option == "highPrice")
            {
                var highPrice = (from b in _db.books
                                 orderby b.cost descending
                                 join a in _db.authors on b.author equals a.authorName
                                 select new BookListViewModel
                                 {
                                     id = b.Id,
                                     title = b.title,
                                     author = a,
                                     rating = b.rating,
                                     image = b.image,
                                     cost = b.cost
                                 }).ToList();
                return highPrice;
            }
            if (option == "lowPrice")
            {
                var lowPrice = (from b in _db.books
                                orderby b.cost
                                join a in _db.authors on b.author equals a.authorName
                                select new BookListViewModel
                                {
                                    id = b.Id,
                                    title = b.title,
                                    author = a,
                                    rating = b.rating,
                                    image = b.image,
                                    cost = b.cost
                                }).ToList();
                return lowPrice;
            }
            if (option == "mostPopular")
            {
                var highPrice = (from b in _db.books
                                 orderby b.copiesSold descending
                                 join a in _db.authors on b.author equals a.authorName
                                 select new BookListViewModel
                                 {
                                     id = b.Id,
                                     title = b.title,
                                     author = a,
                                     rating = b.rating,
                                     image = b.image,
                                     cost = b.cost
                                 }).ToList();
                return highPrice;
            }
            else
            {
                //skila auðum lista ef ekkert er valið
                return new List<BookListViewModel>();
            }
        }

        public List<BookListViewModel> GetTopBooks(string value, int count)
        {
            if (value == "mostPopular")
            {
                var mostPopular = (from b in _db.books
                                   orderby b.copiesSold descending
                                   join a in _db.authors on b.author equals a.authorName
                                   select new BookListViewModel
                                   {
                                       id = b.Id,
                                       title = b.title,
                                       author = a,
                                       rating = b.rating,
                                       image = b.image,
                                       cost = b.cost
                                   }).Take(count).ToList();
                return mostPopular;
            }
            if (value == "rating")
            {
                var topRated = (from b in _db.books
                                orderby b.rating descending
                                join a in _db.authors on b.author equals a.authorName
                                select new BookListViewModel
                                {
                                    id = b.Id,
                                    title = b.title,
                                    author = a,
                                    rating = b.rating,
                                    image = b.image,
                                    cost = b.cost
                                }).Take(count).ToList();
                return topRated;
            }
            else
            {
                var lowPrice = (from b in _db.books
                                orderby b.cost
                                join a in _db.authors on b.author equals a.authorName
                                select new BookListViewModel
                                {
                                    id = b.Id,
                                    title = b.title,
                                    author = a,
                                    rating = b.rating,
                                    image = b.image,
                                    cost = b.cost
                                }).Take(count).ToList();
                return lowPrice;
            }
        }

        public List<BookListViewModel> GetSearchedResults(string search)
        {
            var searchedResults = (from b in _db.books

                                   where b.author.ToLower().Contains(search.ToLower()) ||
                                   b.title.ToLower().Contains(search.ToLower()) ||
                                   b.genre.ToLower().Contains(search.ToLower())
                                   join a in _db.authors on b.author equals a.authorName
                                   select new BookListViewModel
                                   {
                                       id = b.Id,
                                       title = b.title,
                                       author = a,
                                       rating = b.rating,
                                       image = b.image,
                                       cost = b.cost
                                   }).ToList();
            return searchedResults;
        }

        public void UpdateABook(Book change, int bookId)
        {
            var original = (from b in _db.books
                            where b.Id == bookId
                            select b).FirstOrDefault();
            original = change;
            _db.SaveChanges();
        }

        //Ná í bók fyrir Account (GULLI)
        public Book getFavoriteBook()
        {
            var books = (from b in _db.books
                         select b).First();
            return books;
        }
    }
}