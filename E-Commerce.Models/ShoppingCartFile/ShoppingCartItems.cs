using E_Commerce.Models.Product;

namespace E_Commerce.Models.ShoppingCartFile
{
    public class ShoppingCartItems
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
        public virtual ProductItem? Product { get; set; }
        public virtual ShoppingCart? ShoppingCart { get; set; }
    }
}
