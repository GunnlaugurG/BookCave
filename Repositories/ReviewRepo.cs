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

        public List<Review> GetAllReviews(){
            var allReview = new List<Review>();
            //þetta skilar öllum review úr gagnagrunni
            return allReview;
        }

        public void SetReview( Review review){
            // Hér skrifa ég review i gagnagrunn
        }
    }
}