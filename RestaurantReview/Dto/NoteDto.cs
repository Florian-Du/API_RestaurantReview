using RestaurantReview.Models;

namespace RestaurantReview.Dto
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public UserDto User { get; set; }
    }
}
