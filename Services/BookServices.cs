using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModel;
using BookCave.Repositories;

public enum select
{
    topRating,
    topPrice,
    topName,
    bottomPrice
};

namespace BookCave.Services
{
    public class BookServices
    {
        private BookRepo _bookRepo;
        private ReviewRepo _reviewRepo;
        public BookServices()
        {
            _reviewRepo = new ReviewRepo();
            _bookRepo = new BookRepo();
        }

        public List<BookListViewModel> GetAllBooks()
        {
            _bookRepo.GetAllBooks();
            return null;
        }

        public List<BookListViewModel> GetSearchedResults(string search) {

            var searchedResults = (from b in _bookRepo.GetAllBooks()
                                   where b.author.ToLower().Contains(search.ToLower())||
                                   b.title.ToLower().Contains(search.ToLower()) || 
                                   b.genre.ToLower().Contains(search.ToLower())
                                   select new BookListViewModel
                                   {
                                        id = b.Id,
                                        title = b.title,
                                        author = b.author,
                                        rating = b.rating,
                                        image = b.image,
                                        cost = b.cost
                                   }).ToList();        
                                return searchedResults;
        }
        public BookDetailsViewModel GetBookByID(int id)
        {
            var bookByID = (from b in _bookRepo.GetAllBooks()
                            where b.Id == id
                            select new BookDetailsViewModel
                            {
                                id = b.Id,
                                name = b.title,
                                author = b.author,
                                description = b.description,
                                image = b.image,
                                price = b.cost,
                                ratings = b.rating
                            }).FirstOrDefault();
            /// Þarf að filla inn Comments lika
            return bookByID;
        }

        public List<BookListViewModel> GetBooksByGenre(string genre)
        {
            // Flokkar bækur eftir tegund fyrir "Flokka eftir tegund" dropdown listann í navbar
            var sortBy = (from b in _bookRepo.GetAllBooks()
                          where b.genre.ToLower().Contains(genre.ToLower())
                          select new BookListViewModel
                          {
                              id = b.Id,
                              title = b.title,
                              author = b.author,
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
                var topPrice = (from b in _bookRepo.GetAllBooks()
                                 orderby b.cost descending
                                 select new BookListViewModel
                                 {
                                     id = b.Id,
                                     title = b.title,
                                     author = b.author,
                                     rating = b.rating,
                                     image = b.image,
                                     cost = b.cost
                                 }).Take(count).ToList();
                return topPrice;
            } 
            else if (value == select.topPrice)
            {
                var topPrice = (from b in _bookRepo.GetAllBooks()
                                orderby b.cost descending
                                select new BookListViewModel
                                {
                                    id = b.Id,
                                    title = b.title,
                                    author = b.author,
                                    rating = b.rating,
                                    image = b.image,
                                    cost = b.cost
                                }).Take(count).ToList();
                return topPrice;
            }
            else if (value == select.topName)
            {
                var topName = (from b in _bookRepo.GetAllBooks()
                               orderby b.title
                               select new BookListViewModel
                               {
                                   id = b.Id,
                                   title = b.title,
                                   author = b.author,
                                   rating = b.rating,
                                   image = b.image,
                                   cost = b.cost
                               }).Take(count).ToList();
                return topName;
            }
            else if (value == select.bottomPrice)
            {
                var bottomPrice = (from b in _bookRepo.GetAllBooks()
                                   orderby b.cost ascending
                                   select new BookListViewModel
                                   {
                                       id = b.Id,
                                       title = b.title,
                                       author = b.author,
                                       rating = b.rating,
                                       image = b.image,
                                       cost = b.cost
                                   }).Take(count).ToList();
                return bottomPrice;
            }
            else if( value == select.topRating)
            {
             var topRating = (from b in _bookRepo.GetAllBooks()
                                 orderby b.rating descending
                                 select new BookListViewModel
                                 {
                                     id = b.Id,
                                     title = b.title,
                                     author = b.author,
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

        public void SetBookReview( ReviewInputModel inputFromUser ) {
            
            var reviewForBook = ( from r in _reviewRepo.GetAllReviews()
                                    where r.bookId == inputFromUser.bookId
                                    select r).ToList();
            double sumOfAllReview = inputFromUser.Ratings;
            for( int i = 0; i < reviewForBook.Count; i++){
                sumOfAllReview += reviewForBook[i].Ratings;
            }
            double newRating = sumOfAllReview / (reviewForBook.Count + 1);

            Review newReview = new Review { bookId = inputFromUser.bookId,
                                            Ratings = inputFromUser.Ratings,
                                            Description = inputFromUser.Description};
            _reviewRepo.SetReview( newReview );

            /// TODO: upfæra bók í gagnagrunni
            //GetBookByID( inputFromUser.bookId );
            //_bookRepo.UpdateABook( new Book{});
        }
    }
}