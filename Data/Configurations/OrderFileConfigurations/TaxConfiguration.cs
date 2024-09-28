using E_Commerce.Models.OrderFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.OrderFileConfigurations
{
    public class TaxConfiguration : IEntityTypeConfiguration<Tax>
    {
        public void Configure(EntityTypeBuilder<Tax> builder)
        {
            builder.Property(p => p.TaxRate).IsRequired();
        }
    }
}
