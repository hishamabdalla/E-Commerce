namespace E_Commerce.Models.Product
{
    public class CategoryPromotion
    {
        //[ForeignKey("ProductCategorys")]
        public int CategoryId { get; set; }
        //[ForeignKey("Promotion")]
        public int PromotionId { get; set; }

        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual Promotion? Promotion { get; set; }
    }
}
