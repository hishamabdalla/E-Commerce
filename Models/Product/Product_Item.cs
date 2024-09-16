namespace E_Commerce.Models.Product
{
    public class Product_Item
    {
        public int Id { get; set; }
        public string SKU { get; set; }

        public int QuantityInStock { get; set; }

        public string Image { get; set; }
        public double Price { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product? Product { get; set; }


    }
}
