namespace E_Commerce.Models
{
    public class ShoppingCartItems
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductItemId { get; set; }
// comment
        public int Quantity { get; set; }
    }
}
