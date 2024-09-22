namespace E_Commerce.Models.Product
{
    public class CategoryPromotion
    {
        [ForeignKey("ProductCategories")]
        public int CategoryId { get; set; }
        [ForeignKey("Promotion")]
        public int PromotionId { get; set; }

        public ProductCategorie ProductCategories { get; set; }
        public Promotion Promotion { get; set; }
    }
}
