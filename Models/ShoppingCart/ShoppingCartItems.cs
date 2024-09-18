namespace E_Commerce.Models.ShoppingCart
{
    public class ShoppingCartItems
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductItemId { get; set; }
        public int Quantity { get; set; }
    }
}
