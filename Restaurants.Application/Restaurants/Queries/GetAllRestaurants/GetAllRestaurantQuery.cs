using System;
using MediatR;
using Restaurants.Application.Dtos.Restaurants;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantQuery : IRequest<IEnumerable<RestaurantDto>>
{

}
