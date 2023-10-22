using RestaurantReview.Models;

namespace RestaurantReview.Dto
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ResponseDto> Responses { get; set; }
    }
}
