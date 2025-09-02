using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence.Configuration
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {

        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            //tells efcore to treat address as just a sub entity of restaurant without it being its own table in the database. efcore takes the properties of the address class and adds it to the restaurant table 
            builder.OwnsOne(r => r.Address);
            builder.HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurantId); 
        }
    }
}
