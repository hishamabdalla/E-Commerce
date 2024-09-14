namespace E_Commerce.Models.Product
{
    public class ProductCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("ParentCategory")]
        public int ParentCategoryId { get; set; }

        public virtual ProductCategories? ParentCategory { get; set; }
        public ICollection<CategoryPromotion>? PromotionCategories { get; set; }
        public ICollection<Product>? Product { get; set; }

    }
}
