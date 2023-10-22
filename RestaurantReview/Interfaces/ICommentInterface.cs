using RestaurantReview.Models;

namespace RestaurantReview.Interfaces
{
    public interface ICommentInterface
    {
        ICollection<Comment> GetComments();
        ICollection<Comment> GetCommentRestaurant(Guid Id);
        Comment getComment(Guid Id);
        bool CommentExist(Guid Id);
        bool CreateComment(Comment comment);
        bool Save();
    }
}
