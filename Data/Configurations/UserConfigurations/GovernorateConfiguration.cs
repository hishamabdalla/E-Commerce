using E_Commerce.Models.UserFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.UserConfigurations
{
    public class GovernorateConfiguration : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> builder)
        {
            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(g => g.OrderPrice)
                .IsRequired();

            builder.HasMany(g => g.UserAddresses)
                .WithOne(a => a.Governorate)
                .HasForeignKey(a => a.GovernorateID);
        }
    }
}
