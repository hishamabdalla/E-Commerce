﻿using E_Commerce.Models.Product;

namespace E_Commerce.DataAccessData.Configurations.ProductFileConfigurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            // self relationship (many to one)
            builder.HasOne(c => c.ParentCategory)
                .WithMany(c=>c.ChildCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
