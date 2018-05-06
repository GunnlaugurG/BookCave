namespace BookCave.Data.EntityModels {
   public class Review {
        public int id{ get; set; }
        public int bookId{ get; set; }
        public string Description {get; set; }
        public double Ratings {get; set; }
    }

}