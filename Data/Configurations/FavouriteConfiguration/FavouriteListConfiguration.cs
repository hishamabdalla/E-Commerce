using E_Commerce.Models.Favourite;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.FavouriteConfiguration
{
    public class FavouriteListConfiguration : IEntityTypeConfiguration<FavouriteList>
    {
        public void Configure(EntityTypeBuilder<FavouriteList> builder)
        {
            
        }
    }
}
