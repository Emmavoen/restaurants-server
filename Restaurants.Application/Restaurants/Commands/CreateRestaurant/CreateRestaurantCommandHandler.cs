using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IRestaurantRepository repository) : IRequestHandler<CreateRestaurantCommand, int>
{

    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new restaurant {@Restaurant}" , request);
        var restaurant = new Restaurant
        {
            Name = request.Name,
            Description = request.Description,
            Category = request.Category,
            HasDelivery = request.HasDelivery,
            ContactNumber = request.ContactNumber,
            ContactEmail = request.ContactEmail,
            Address = new Address
            {
                Street = request.Street,
                City = request.City,
                PostalCode = request.PostalCode
            },
        };

        int id = await repository.Create(restaurant);
        return id;
    }
}