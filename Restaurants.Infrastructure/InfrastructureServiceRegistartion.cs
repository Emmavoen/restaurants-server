using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence.DatabaseContext;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.seeders;

namespace Restaurants.Infrastructure
{
    public static class InfrastructureServiceRegistartion
    {
        public static IServiceCollection  RegisterPersistenceService(this IServiceCollection services, IConfiguration conn)
        { 
            services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(conn.GetConnectionString("conn")).EnableSensitiveDataLogging());
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            return services;
        }
    }
}
