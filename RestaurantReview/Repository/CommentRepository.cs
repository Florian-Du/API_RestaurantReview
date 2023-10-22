using Microsoft.EntityFrameworkCore;
using RestaurantReview.Data;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Repository
{
    public class CommentRepository : ICommentInterface
    {
        private readonly DataContext _context;

        public CommentRepository(DataContext context)
        {
            _context = context;
        }

        public bool CommentExist(Guid Id)
        {
            if (_context.Comments.Any(r => r.Id == Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateComment(Comment comment)
        {
            _context.Add(comment);
            return Save();
        }

        public Comment getComment(Guid Id)
        {
            return _context.Comments.Where(c => c.Id == Id).FirstOrDefault();
        }

        public ICollection<Comment> GetCommentRestaurant(Guid Id)
        {
            return _context.Comments.Where(c => c.Restaurant.Id == Id).Include(r => r.Responses).ToList();
        }

        public ICollection<Comment> GetComments()
        {
            return _context.Comments.OrderBy(c => c.Id).Include(r => r.Responses).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
