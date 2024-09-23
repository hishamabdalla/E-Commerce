using E_Commerce.Models.UserFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.UserConfigurations
{
    public class UserAddressesConfiguration : IEntityTypeConfiguration<UserAddresses>
    {
        public void Configure(EntityTypeBuilder<UserAddresses> builder)
        {
            builder.HasOne(ads => ads.User)
                .WithMany(u => u.UserAddresses)
                .HasForeignKey(ads => ads.UserId);

            builder.HasOne(ads => ads.UserAddress)
                .WithMany(ad => ad.UserAddresses)
                .HasForeignKey(ads => ads.UserId);

            builder.HasKey(ads => new { ads.UserId, ads.AddressId });
        }
    }
}
