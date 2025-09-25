using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos.Restaurants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

public class RestaurantService(IRestaurantRepository repository, ILogger<RestaurantService> logger) : IRestaurantService
{
    public async Task<int> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation("Creating a new restaurant");
        var restaurant = new Restaurant
        {
            Name = dto.Name,
            Description = dto.Description,
            Category = dto.Category,
            HasDelivery = dto.HasDelivery,
            ContactNumber = dto.ContactNumber,
            ContactEmail = dto.ContactEmail,
            Address = new Address
            {
                Street = dto.Street,
                City = dto.City,
                PostalCode = dto.PostalCode
            },
            Dishes = dto.Dishes?.Select(d => new Dish
            {
                Name = d.Name,
                Description = d.Description,
                Price = d.Price
            }).ToList() ?? []
        };

        int id = await repository.Create(restaurant);
        return id;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurant()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await repository.GetAllAsync();
        var  result =  restaurants.Select(RestaurantDto.FromEntity);
        return result!;

    }
    public async Task<RestaurantDto?> GetByIdAsync(int id)
    {
        logger.LogInformation("Getting restaurant by id: {Id}", id);
        var restaurant = await repository.GetByIdAsync(id);
        var result  =  RestaurantDto.FromEntity(restaurant);
        return result;
    }

}
