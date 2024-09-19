using E_Commerce.Models.Product;

namespace E_Commerce.Models.ShoppingCart
{
    public class ShoppingCartItems
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        [ForeignKey("Product")]
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
        public Product_Item? Product { get; set; }
    }
}
