namespace RestaurantReview.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Note>? Notes { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
