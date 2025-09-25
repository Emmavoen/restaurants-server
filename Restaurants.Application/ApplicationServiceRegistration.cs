
using System.Reflection;

using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;

namespace Restaurants.Application;

public static class ApplicationServiceRegistartion
{
    public static IServiceCollection RegisterApplicationService(this IServiceCollection services)
    {   
        var applicationAssembly = typeof(Microsoft.Extensions.DependencyInjection.ServiceCollectionExtensions).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IRestaurantService, RestaurantService>();
            //services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();

        return services;
    }
}
