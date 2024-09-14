namespace E_Commerce.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public ProductCategories? Category { get; set; }

        public ICollection<Product_Item>? Items { get; set; }
    }
}
