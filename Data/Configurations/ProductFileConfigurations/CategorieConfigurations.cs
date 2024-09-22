using E_Commerce.Models.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.ProductFileConfigurations
{
    public class CategorieConfigurations : IEntityTypeConfiguration<ProductCategorie>
    {
        public void Configure(EntityTypeBuilder<ProductCategorie> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            // self relationship (many to one)
            builder.HasOne(c => c.ParentCategory)
                .WithMany()
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
