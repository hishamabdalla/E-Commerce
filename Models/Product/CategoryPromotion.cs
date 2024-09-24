namespace E_Commerce.Models.Product
{
    public class CategoryPromotion
    {
        //[ForeignKey("ProductCategories")]
        public int CategoryId { get; set; }
        //[ForeignKey("Promotion")]
        public int PromotionId { get; set; }

        public virtual ProductCategorie? ProductCategorie { get; set; }
        public virtual Promotion? Promotion { get; set; }
    }
}
