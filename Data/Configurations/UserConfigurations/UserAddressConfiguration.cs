using E_Commerce.Models.UserFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.UserConfigurations
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
    {
        public void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            builder.Property(a => a.City)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(a => a.Region)
                .IsRequired();

            builder.Property(a => a.PostalCode)
                .IsRequired();

            builder.Property(a => a.PostalCode)
                .IsRequired();

        }
    }
}
