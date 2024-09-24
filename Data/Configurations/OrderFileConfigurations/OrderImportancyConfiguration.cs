using E_Commerce.Models.OrderFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.OrderFileConfigurations
{
    public class OrderImportancyConfiguration : IEntityTypeConfiguration<OrderImportancy>
    {
        public void Configure(EntityTypeBuilder<OrderImportancy> builder)
        {
            builder.HasKey(o => o.Id);

            builder.ToTable("OrderImportancies");

            builder.Property(o => o.Name)
                  .IsRequired() 
                  .HasMaxLength(100);

            builder.Property(o => o.Price)
                  .IsRequired();

            builder.HasMany(o => o.Orders)
                .WithOne(i => i.OrderImportancy)
                .HasForeignKey(o => o.ImportancyId);
        }
    }
}
