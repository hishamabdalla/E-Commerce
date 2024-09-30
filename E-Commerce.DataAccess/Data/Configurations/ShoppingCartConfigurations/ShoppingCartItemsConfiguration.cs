using E_Commerce.Models.ShoppingCartFile;

namespace E_Commerce.DataAccessData.Configurations.ShoppingCartConfigurations
{
    public class ShoppingCartItemsConfiguration : IEntityTypeConfiguration<ShoppingCartItems>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItems> builder)
        {
            builder.Property(si => si.Quantity)
                .IsRequired();

            builder.HasOne(si => si.Product)
                .WithMany(pi => pi.ShoppingCartItems)
                .HasForeignKey(si => si.ProductItemId);

            builder.HasOne(si => si.ShoppingCart)
                .WithMany(s => s.ShoppingCartItems)
                .HasForeignKey(si => si.ShoppingCartId);
        }
    }
}
