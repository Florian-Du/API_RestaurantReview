using RestaurantReview.Models;

namespace RestaurantReview.Dto
{
    public class ResponseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
