using Restaurants.Application.Dtos.Dishes;

namespace Restaurants.Application.Dtos.Restaurants;

public class CreateRestaurantDto
{
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public bool HasDelivery { get; set; }
        public string? ContactNumber { get; set; }
        public string? ContactEmail { get; set; }
         public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public List<DishDto> Dishes { get; set; } = [];
}