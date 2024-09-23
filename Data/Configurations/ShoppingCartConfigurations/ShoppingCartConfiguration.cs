using E_Commerce.Models.ShoppingCartFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.ShoppingCartConfigurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasOne(s => s.User)
                .WithMany(u => u.ShoppingCarts)
                .HasForeignKey(s => s.UserId);

            builder.HasMany(s => s.ShoppingCartItems)
                .WithOne(si => si.ShoppingCart)
                .HasForeignKey(si => si.ShoppingCartId);
        }
    }
}
