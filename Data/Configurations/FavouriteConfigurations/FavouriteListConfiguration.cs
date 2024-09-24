using E_Commerce.Models.Favourite;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.FavouriteConfiguration
{
    public class FavouriteListConfiguration : IEntityTypeConfiguration<FavouriteList>
    {
        public void Configure(EntityTypeBuilder<FavouriteList> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("FavouriteLists");

            builder.HasMany(f => f.FavouriteListItems).
                WithOne(f => f.FavouriteList)
                 .HasForeignKey(i => i.FavouriteListId);

            builder.HasOne(f => f.User)
                .WithMany(u => u.FavouriteLists)
                .HasForeignKey(f => f.UserId);
               
                
        }
    }
}
