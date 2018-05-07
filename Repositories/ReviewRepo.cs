using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories {

    public class ReviewRepo  {

        private DataContext _db;
        public ReviewRepo(){
            _db = new DataContext();
        }

        public List<Review> GetReviewByBookId( int bookId ){
            var ReviewByBookId = ( from r in _db.Reviews
                                    where r.reviewBookId == bookId
                                    select r).ToList();
            
            return ReviewByBookId;
        }

        public void SetReview( Review review){
            // Hér skrifa ég review i gagnagrunn
        }
    }
}