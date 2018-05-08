using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookCave.Repositories
{
    public class ReviewRepo
    {
        private DataContext _db;

        public ReviewRepo()
        {
            _db = new DataContext();
        }

        public List<ReviewTwo> GetReviewByBookId(int bookId)
        {
            var ReviewByBookId = (from r in _db.reviewTwo
                                  where r.reviewBookId == bookId
                                  select r).ToList();

            return ReviewByBookId;
        }
        public List<CommentsViewModel> GetReviewViewModelByBookId(int bookId)
        {
            var ReviewByBookId = (from r in _db.reviewTwo
                                  where r.reviewBookId == bookId
                                  select new CommentsViewModel{
                                      Author = r.reviewFromUserName,
                                      Description = r.Description,
                                      Ratings = r.Ratings
                                  }).ToList();

            return ReviewByBookId;
        }

        public void SetReview(ReviewTwo review)
        {
            _db.Add(review);
            _db.SaveChanges();
            // Hér skrifa ég review i gagnagrunn
        }
    }
}