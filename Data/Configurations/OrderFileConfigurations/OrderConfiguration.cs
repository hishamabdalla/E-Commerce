using E_Commerce.Models.OrderFile;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.OrderFileConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.PaymentMethodId)
                   .IsRequired(); 

            builder.Property(o => o.UserId)
                   .IsRequired(); 

            builder.Property(o => o.AddressId)
                   .IsRequired(); 

            builder.Property(o => o.OrderStatusId)
                   .IsRequired(); 

            builder.Property(o => o.OrderDate)
                   .IsRequired(); 

            builder.Property(o => o.TotalPrice)
                   .IsRequired() 
                   .HasColumnType("decimal(10,2)"); 

            
            builder.HasOne(o => o.User)
                   .WithMany() 
                   .HasForeignKey(o => o.UserId);

            builder.HasOne(o => o.UserPaymentMethod)
                   .WithMany() 
                   .HasForeignKey(o => o.PaymentMethodId);

            builder.HasOne(o => o.UserAddress)
                   .WithMany() 
                   .HasForeignKey(o => o.AddressId);

            builder.HasOne(o => o.OrderStatus)
                   .WithMany() 
                   .HasForeignKey(o => o.OrderStatusId);

            builder.HasOne(o => o.OrderImportancy)
                   .WithMany() 
                   .HasForeignKey(o => o.ImportancyId);

            builder.HasOne(o => o.Tax)
                   .WithMany() 
                   .HasForeignKey(o => o.TaxId);

            
            builder.HasMany(o => o.OrderLines)
                   .WithOne() 
                   .HasForeignKey(o=>o.OrderId); 
        }
    }
}
