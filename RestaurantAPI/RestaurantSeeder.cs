using RestaurantAPI.Entities;
using System.ComponentModel;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }


        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },

                new Role()
                {
                    Name = "Manager"
                },

                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                     Name = "KFC",
                     Category = "Fast Food",
                     Description = "Food KFC",
                     ContactEmail = "contact@kfc.com",
                     ContactNumber = "555555555555",
                     HasDelivery = true,
                     Dishes = new List<Dish>()
                     {
                        new Dish()
                        {
                              Name = "N Hot Chicken",
                              Description= "XD",
                              Price = 19.3M,
                        },

                        new Dish()
                        {
                              Name = "B Hot Chicken",
                              Description= "XD",
                              Price = 12.3M,
                        },
                     },
                     Address = new Address()
                     {
                         City = "Kraków",
                         Street = "Długa 5",
                         PostalCode = "30-001"
                     }
                },

                new Restaurant()
                {
                     Name = "MC",
                     Category = "Fast Food",
                     Description = "Food MC",
                     ContactEmail = "contact@MC.com",
                     ContactNumber = "666666666666",
                     HasDelivery = true,
                     Dishes = new List<Dish>()
                     {
                        new Dish()
                        {
                              Name = "Burger",
                              Description= "XD",
                              Price = 15.3M,
                        },

                        new Dish()
                        {
                              Name = "Bic Mac",
                              Description= "XD",
                              Price = 18.3M,
                        },
                     },
                     Address = new Address()
                     {
                         City = "Kraków",
                         Street = "Krótka 5",
                         PostalCode = "30-005"
                     }
                }

            };

            return restaurants;
        }
    }
}
