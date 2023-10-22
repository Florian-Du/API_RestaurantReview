using RestaurantReview.Models;

namespace RestaurantReview.Interfaces
{
    public interface IRestaurantInterface
    {
        ICollection<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(Guid Id);
        Restaurant GetRestaurant(string Name);
        bool RestaurantExist(Guid Id);
        bool CreateRestaurant(Restaurant restaurant);
        bool UpdateRestaurant(Restaurant restaurant);
        bool DeleteRestaurant(Restaurant restaurant);
        bool Save();
    }
}
