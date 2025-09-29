using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Command.DeleteDishes
{
    public class DeleteDishesCommandHandler(
        ILogger<DeleteDishesCommandHandler> logger,
        IRestaurantRepository restaurantRepository,
        IDishesRepository dishesRepository
    ) : IRequestHandler<DeleteDishesCommand>
    {
        public async Task Handle(DeleteDishesCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation(
                "Deleting dishes for restaurant: {@RestaurantId}",
                request.RestaurantId
            );
            var restaurant = await restaurantRepository.GetByIdAsync(request.RestaurantId);

            if (restaurant is null)
            {
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            }

            await dishesRepository.Delete(restaurant.Dishes);
        }
    }
}
