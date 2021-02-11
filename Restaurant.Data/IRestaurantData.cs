using Restaurant.Core;
using System.Linq;
using System.Collections.Generic;

namespace Restaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<RestaurantClass> GetRestaurantsByName(string name);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        List<RestaurantClass> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<RestaurantClass>() {
                new RestaurantClass { Id = 1, Name = "Scott's Pizza", Location="Los Angeles", Cuisine = CuisineType.Italian },
                new RestaurantClass { Id = 2, Name = "Mexican Burritos", Location="New York", Cuisine = CuisineType.Mexican },
                new RestaurantClass { Id = 1, Name = "Taj Mahal Indian Food", Location="Austin", Cuisine = CuisineType.Indian }
            };
        }

        public IEnumerable<RestaurantClass> GetRestaurantsByName(string name)
        {
            return from r in restaurants
                    where string.IsNullOrEmpty(name) || r.Name.Contains(name)
                    orderby r.Name
                    select r;
        }
    }
}