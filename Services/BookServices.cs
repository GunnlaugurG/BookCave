using BookCave.Data.EntityModels;
using BookCave.Models.InputModel;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using System.Collections.Generic;

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

        private AccountRepo _accountRepo;
        public BookServices()
        {
            _reviewRepo = new ReviewRepo();
            _bookRepo = new BookRepo();
            _accountRepo = new AccountRepo();
            
        }

        public List<BookListViewModel> GetSearchedResults(string search)
        {
            return _bookRepo.GetSearchedResults(search);
        }

        public BookDetailsViewModel GetBookByID(int id)
        {
            return _bookRepo.GetBookByID(id);
        }

        public List<BookListViewModel> GetBooksByGenre(string genre)
        {
            return _bookRepo.GetBooksByGenre(genre);
        }

        public List<BookListViewModel> SortBy(string option)
        {
            return _bookRepo.SortBy(option);
        }

        public List<BookListViewModel> GetAllBooks()
        {
            return _bookRepo.GetAllBooks();
        }

        public List<BookListViewModel> GetTopBooks(string value, int count) {
            return _bookRepo.GetTopBooks(value,count);
        }
        public void SetBookReview(ReviewInputModel inputFromUser, string user)
        {

            var reviewForBook = _reviewRepo.GetReviewByBookId(inputFromUser.bookId);
            double sumOfAllReview = inputFromUser.Ratings;
            for (int i = 0; i < reviewForBook.Count; i++)
            {
                sumOfAllReview += reviewForBook[i].Ratings;
            }
            double newRating = sumOfAllReview / (reviewForBook.Count + 1);

            ReviewTwo newReview = new ReviewTwo
            {
                reviewBookId = inputFromUser.bookId,
                Ratings = inputFromUser.Ratings,
                Description = inputFromUser.Description,
                reviewFromUserName = _bookRepo.getUserName( user )
            };
            _reviewRepo.SetReview(newReview);

            var updatedBook = _bookRepo.getBookEntityModel( inputFromUser.bookId );
            updatedBook.rating = newRating;
            _bookRepo.UpdateABook( updatedBook, inputFromUser.bookId );
        }
    }
}