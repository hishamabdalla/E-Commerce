using E_Commerce.Models.Favourite;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.FavouriteConfiguration
{
    public class FavouriteListItemsConfiguration : IEntityTypeConfiguration<FavouriteListItems>
    {
        public void Configure(EntityTypeBuilder<FavouriteListItems> builder)
        {
            builder.HasKey(f => new
            {
                f.ProductItemId,
                f.FavouriteListId
            }); 

            builder.HasOne(p => p.Product)
                .WithMany(f => f.FavouriteListItems)
                .HasForeignKey(f => f.ProductItemId);

            builder.HasOne(p => p.FavouriteList)
               .WithMany(f => f.FavouriteListItems)
               .HasForeignKey(f => f.FavouriteListId);

          
        }
    }
}
