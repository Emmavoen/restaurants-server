using MediatR;

namespace Restaurants.Application.Dishes.Command.DeleteDishes;

public class DeleteDishesCommand( int restaurantId) : IRequest
{
    public int RestaurantId { get; set; } = restaurantId;
    

    
}