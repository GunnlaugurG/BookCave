using BookCave.Data;
using BookCave.Data.EntityModels;
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

        public List<Review> GetReviewByBookId(int bookId)
        {
          //  var ReviewByBookId = (from r in _db.reviews
          //                        where r.reviewBookId == bookId
          //                        select r).ToList();
        return null;
//            return ReviewByBookId;
        }

        public void SetReview(Review review)
        {
            _db.Add(review);
        }
    }
}