using E_Commerce.Models.Payment;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.PaymentConfiguration
{
    public class UserPaymentMethodConfiguration : IEntityTypeConfiguration<UserPaymentMethod>
    {
        public void Configure(EntityTypeBuilder<UserPaymentMethod> builder)
        {
            builder.Property(p => p.Provider)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.AccountNumber)
                .HasMaxLength(16)
                .IsRequired();

            builder.Property(p => p.ExpireDate)
                .IsRequired();


            /// RelationShips

            builder.HasOne(p => p.PaymentType)
                .WithMany(t => t.PaymentMethods)
                .HasForeignKey(p => p.PaymentTypeId);

            builder.HasOne(p => p.User)
                .WithMany(u => u.UserPaymentMethods)
                .HasForeignKey(p => p.UserId);


        }    
    }
}
