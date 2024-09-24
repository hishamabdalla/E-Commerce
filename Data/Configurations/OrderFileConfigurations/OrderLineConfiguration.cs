using E_Commerce.Models.OrderFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.OrderFileConfigurations
{
    public class OrderLineConfiguration : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(ol => ol.Id);
     
            builder.ToTable("OrderLines");

            builder.HasOne(ol => ol.Product)
                   .WithMany(p => p.OrderLines)
                   .HasForeignKey(ol => ol.ProductItemId);

            builder.HasOne(ol => ol.Order)
                   .WithMany(o => o.OrderLines)
                   .HasForeignKey(ol => ol.OrderId);

            builder.HasMany(ol => ol.ProductItemReviews)
                   .WithOne(pir => pir.OrderLine)
                   .HasForeignKey(pir => pir.OrderLineId);

            builder.Property(ol => ol.Quantity)
                .IsRequired();

            builder.Property(ol => ol.Price)
                .IsRequired();

        }
    }
}
