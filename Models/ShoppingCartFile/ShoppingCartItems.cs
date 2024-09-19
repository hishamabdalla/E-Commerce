using E_Commerce.Models.Product;

namespace E_Commerce.Models.ShoppingCartFile
{
    public class ShoppingCartItems
    {
        public int Id { get; set; }
        [ForeignKey("ShoppingCart")]
        public int ShoppingCartId { get; set; }
        [ForeignKey("Product")]
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
        public Product_Item? Product { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
    }
}
