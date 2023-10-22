namespace RestaurantReview.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public Restaurant Restaurant { get; set; }
        public User User { get; set; }
    }
}
