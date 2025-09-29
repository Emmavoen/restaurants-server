using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dtos.Dishes;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQueryHandler(ILogger<GetDishByIdForRestaurantQueryHandler> logger, IRestaurantRepository restaurantRepository) : IRequestHandler<GetDishByIdForRestaurantQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdForRestaurantQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting dish: {DishId} for restaurant: {@RestaurantId}", request.DishId, request.RestaurantId);
        var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        }

        var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);

        if (dish is null)
        {
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());
        }
    
    var result = new DishDto
    {
        Id = dish.Id,
        Name = dish.Name,
        Description = dish.Description,
        Price = dish.Price,
        KiloCalories = dish.KiloCalories
    };
    return result;
    }
}