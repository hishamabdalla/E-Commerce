namespace E_Commerce.Models.Product
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("ParentCategory")]
        public int ParentCategoryId { get; set; }
        public virtual ProductCategory? ParentCategory { get; set; }
        public virtual ICollection<ProductCategory> ChildCategories { get; set; } = new HashSet<ProductCategory>();
        public virtual ICollection<CategoryPromotion>? PromotionCategories { get; set; } = new HashSet<CategoryPromotion>();
        public virtual ICollection<Product>? Products { get; set; } = new HashSet<Product>();

    }
}
