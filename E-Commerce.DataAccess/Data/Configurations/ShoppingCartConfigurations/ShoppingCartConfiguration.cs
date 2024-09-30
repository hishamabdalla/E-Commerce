using E_Commerce.Models.ShoppingCartFile;

namespace E_Commerce.DataAccessData.Configurations.ShoppingCartConfigurations
{
    public class ShoppingCartConfiguration : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasOne(s => s.User)
                .WithMany(u => u.ShoppingCarts)
                .HasForeignKey(s => s.UserId);

        }
    }
}
