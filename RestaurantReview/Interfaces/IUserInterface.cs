using RestaurantReview.Models;

namespace RestaurantReview.Interfaces
{
    public interface IUserInterface
    {
        ICollection<User> getUsers();
        User getUser(Guid Id);
        User getUser(string UserEmail);
        bool UserExist(Guid Id);
        bool CreateUser(User user);
        bool Save();

    }
}
