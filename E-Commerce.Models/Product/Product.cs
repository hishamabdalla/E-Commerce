namespace E_Commerce.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<ProductItem>? Items { get; set; } = new HashSet<ProductItem>();
    }
}
