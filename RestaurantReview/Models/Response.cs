namespace RestaurantReview.Models
{
    public class Response
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Comment Comment { get; set; }

    }
}
