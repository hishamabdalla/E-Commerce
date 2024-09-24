namespace E_Commerce.Models.Product
{
    public class ProductCategorie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[ForeignKey("ParentCategory")]
        public int ParentCategoryId { get; set; }

        public virtual ProductCategorie? ParentCategory { get; set; }
        public virtual ICollection<CategoryPromotion>? PromotionCategories { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}
