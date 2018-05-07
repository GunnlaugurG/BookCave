using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;
        public BookRepo() {
            _db = new DataContext();
        }
        public List<BookListViewModel> GetAllBooks() {
           var books = (from b in _db.books
                        join a in _db.authors on b.keyAuthorId equals a.Id
                        select new BookListViewModel {
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
                                rating = b.rating
                            }).SingleOrDefault();
            /// Þarf að filla inn Comments lika
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

        public List<BookListViewModel> GetTopBooks(select value, int count)
        {
            if(value == select.topPrice)
            {
                var topPrice = (from b in _db.books
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
                                 }).Take(count).ToList();
                return topPrice;
            } 
            else if (value == select.bottomPrice)
            {
                var bottomPrice = (from b in _db.books
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
                return bottomPrice;
            }
            else if (value == select.topName)
            {
                var topName = (from b in _db.books
                               orderby b.title
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
                return topName;
            }
            
            else if( value == select.topRating)
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
                                 }).Take(count).ToList();
                return topRating;
            } 
            else{
                //skila auðum lista ef ekkert er valið
                return new List<BookListViewModel>();
            }

        }


        public List<BookListViewModel> GetSearchedResults(string search) {
                var searchedResults = (from b in _db.books

                            where b.author.ToLower().Contains(search.ToLower())||
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
                                cost = b.cost}).ToList();        
                                return searchedResults;
        }
        public void UpdateABook( Book book ){
            // hér þarf að updeita book
        }
        //Ná í bók fyrir Account (GULLI)
        public Book getFavoriteBook(){
                var books = (from b in _db.books 
                            select b).First();
            return books;
        }

    }
}
