using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Command.CreateDish
{
    public class CreateDishCommandHandler(
        ILogger<CreateDishCommandHandler> logger,
        IRestaurantRepository repository,
        IDishesRepository dishesRepository
    ) : IRequestHandler<CreateDishCommand, int>
    {
        public async Task<int> Handle(
            CreateDishCommand request,
            CancellationToken cancellationToken
        )
        {
            logger.LogInformation("Creating new dish: {@DishRequest}", request);
            var restaurant = await repository.GetByIdAsync(request.RestaurantId);
            if (restaurant == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }
            var dish = new Dish
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                KiloCalories = request.KiloCalories,
                RestaurantId = request.RestaurantId,
            };
            return await dishesRepository.Create(dish);

            // return Task.CompletedTask;
        }
    }
}
