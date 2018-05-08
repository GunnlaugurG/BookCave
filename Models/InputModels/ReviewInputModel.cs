namespace BookCave.Models.InputModel
{
    public class ReviewInputModel
    {
        public int bookId { get; set; }
        public string Description { get; set; }
        public double Ratings { get; set; }
    }
}