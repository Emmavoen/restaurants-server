using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence.DatabaseContext;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantRepository(RestaurantsDbContext context) : IRestaurantRepository
{
    public async Task<int> Create(Restaurant restaurant)
    {
        context.Restaurants.Add(restaurant);
        await context.SaveChangesAsync();
        return restaurant.Id;
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await context.Restaurants.ToListAsync();
        return restaurants;
    }
    public async Task<Restaurant?> GetByIdAsync(int id)
    {
        var restaurant = await context.Restaurants.Include(r => r.Dishes).FirstOrDefaultAsync(r => r.Id == id);
        return restaurant;
    }

    public async Task Delete(Restaurant entity)
    {
        context.Remove(entity);
        await context.SaveChangesAsync();
    }

    public Task SaveChanges()
    {
        return context.SaveChangesAsync();
    }
}