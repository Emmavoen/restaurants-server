using Restaurants.Application.Dtos.Restaurants;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurant();
        Task<RestaurantDto?> GetByIdAsync(int id);
        Task<int> Create(CreateRestaurantDto dto);
    }
}