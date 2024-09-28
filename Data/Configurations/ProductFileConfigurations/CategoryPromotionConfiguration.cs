using E_Commerce.Models.Product;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Data.Configurations.ProductFileConfigurations
{
    public class CategoryPromotionConfiguration : IEntityTypeConfiguration<CategoryPromotion>
    {
        public void Configure(EntityTypeBuilder<CategoryPromotion> builder)
        {
            builder.HasOne(cp => cp.Promotion)
                .WithMany(promotion => promotion.PromotionCategories)
                .HasForeignKey(cp => cp.PromotionId);

            builder.HasOne(cp => cp.ProductCategory)
                .WithMany(pc => pc.PromotionCategories)
                .HasForeignKey(cp => cp.CategoryId);

            /// composite primary key
            builder.HasKey(p => new {p.PromotionId, p.CategoryId});
        }
    }
}
