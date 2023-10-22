namespace RestaurantReview.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public Restaurant Restaurant { get; set; }
        public ICollection<Response>? Responses {  get; set; }
    }
}
