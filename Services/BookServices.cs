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
       public List<BookListViewModel> GetSearchedResults(string search) {

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
            return _bookRepo.GetTopBooks(value,count);
        }

        public void SetBookReview( ReviewInputModel inputFromUser ) {
            
            var reviewForBook = ( from r in _reviewRepo.GetAllReviews()
                                    where r.reviewBookId == inputFromUser.bookId
                                    select r).ToList();
            double sumOfAllReview = inputFromUser.Ratings;
            for( int i = 0; i < reviewForBook.Count; i++){
                sumOfAllReview += reviewForBook[i].Ratings;
            }
            double newRating = sumOfAllReview / (reviewForBook.Count + 1);

            Review newReview = new Review { reviewBookId = inputFromUser.bookId,
                                            Ratings = inputFromUser.Ratings,
                                            Description = inputFromUser.Description};
            _reviewRepo.SetReview( newReview );

            /// TODO: upfæra bók í gagnagrunni
            //GetBookByID( inputFromUser.bookId );
            //_bookRepo.UpdateABook( new Book{});
        }
    }
}