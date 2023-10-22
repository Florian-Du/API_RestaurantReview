using RestaurantReview.Data;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);
            return Save();
        }

        public User getUser(Guid Id)
        {
            return _context.Users.Where(u => u.Id == Id).FirstOrDefault();
        }

        public User getUser(string UserEmail)
        {
            return _context.Users.Where(u => u.UserEmail == UserEmail).FirstOrDefault();
        }

        public ICollection<User> getUsers()
        {
            return _context.Users.OrderBy(p => p.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExist(Guid Id)
        {
            if (_context.Users.Any(r => r.Id == Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
