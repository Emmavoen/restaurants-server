using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Infrastructure.Persistence.DatabaseContext;
using Restaurants.Infrastructure.seeders;

namespace Restaurants.Infrastructure
{
    public static class InfrastructureServiceRegistartion
    {
        public static IServiceCollection  RegisterPersistenceService(this IServiceCollection services, IConfiguration conn)
        { 
            services.AddDbContext<RestaurantsDbContext>(options => options.UseSqlServer(conn.GetConnectionString("conn")));
            services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
            return services;
        }
    }
}
