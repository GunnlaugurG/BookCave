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

        public BookServices()
        {
            _reviewRepo = new ReviewRepo();
            _bookRepo = new BookRepo();
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

        public List<BookListViewModel> GetTopBooks(select value, int count)
        {
            return _bookRepo.GetTopBooks(value, count);
        }

        public List<BookListViewModel> GetAllBooks()
        {
            return _bookRepo.GetAllBooks();
        }

        public void SetBookReview(ReviewInputModel inputFromUser)
        {
            var reviewForBook = _reviewRepo.GetReviewByBookId(inputFromUser.bookId);
            if( reviewForBook != null){
                double sumOfAllReview = inputFromUser.Ratings;
                for (int i = 0; i < reviewForBook.Count; i++)
                {
                   sumOfAllReview += reviewForBook[i].Ratings;
                }
                double newRating = sumOfAllReview / (reviewForBook.Count + 1);
            }
            Review newReview = new Review
            {
                reviewBookId = inputFromUser.bookId,
                Ratings = inputFromUser.Ratings,
                Description = inputFromUser.Description,
                reviewFromUserName = "Unknown"
            };
            _reviewRepo.SetReview(newReview);

            /// TODO: upfæra bók í gagnagrunni
            //GetBookByID( inputFromUser.bookId );
            //_bookRepo.UpdateABook( new Book{});
        }
    }
}