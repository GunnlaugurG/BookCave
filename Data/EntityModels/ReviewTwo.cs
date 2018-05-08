namespace BookCave.Data.EntityModels
{
    public class ReviewTwo
    {
        public string Id { get; set; }
        public int reviewBookId { get; set; }
        public string Description { get; set; }
        public double Ratings { get; set; }
        public string reviewFromUserName { get; set; }
    }
}