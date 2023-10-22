using Azure;
using RestaurantReview.Data;
using RestaurantReview.Interfaces;
using RestaurantReview.Models;

namespace RestaurantReview.Repository
{
    public class RestaurantRepository : IRestaurantInterface
    {
        private readonly DataContext _context;

        public RestaurantRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateRestaurant(Restaurant restaurant)
        {
            _context.Add(restaurant);
            return Save();
        }

        public Restaurant GetRestaurant(Guid Id)
        {
            return _context.Restaurants.Where(r => r.Id == Id).FirstOrDefault();
        }

        public Restaurant GetRestaurant(string Name)
        {
            return _context.Restaurants.Where(r => r.Name == Name).FirstOrDefault();
        }

        public ICollection<Restaurant> GetRestaurants()
        {
            return _context.Restaurants.OrderBy(p => p.Id).ToList();
        }

        public bool RestaurantExist(Guid Id)
        {
            if (_context.Restaurants.Any(r => r.Id == Id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            _context.Update(restaurant);
            return Save();
        }
    }
}
