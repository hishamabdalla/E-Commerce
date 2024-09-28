using E_Commerce.Models.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;

namespace E_Commerce.Data.Configurations.ProductFileConfigurations
{
    public class ProductItemConfigurations : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.Property(i => i.SKU)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(i => i.QuantityInStock)
                .IsRequired();

            builder.Property(i => i.Image)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(i => i.Price)
                .HasColumnType("decimal(9, 2)");

            // RelationShip With Products(Many to One)
            builder.HasOne(p => p.Product)
                .WithMany(i => i.Items)
                .HasForeignKey(i => i.ProductId);
        }
    }
}
