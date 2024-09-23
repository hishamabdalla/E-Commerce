using E_Commerce.Models.UserFile;

namespace E_Commerce.Models.ShoppingCartFile
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<ShoppingCartItems>? ShoppingCartItems { get; set; }
    }
}
