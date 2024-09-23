using E_Commerce.Models.UserFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.UserConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(u => u.UserName)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.Property(u => u.DateOfBirth)
                .IsRequired();

            builder.HasMany(u => u.UserAddresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId);

            builder.HasMany(u => u.FavouriteLists)
                .WithOne(f => f.User)
                .HasForeignKey(f => f.UserId);

            builder.HasMany(u => u.UserPaymentMethods)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            builder.HasMany(u => u.ShoppingCarts)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId);
        }
    }
}
