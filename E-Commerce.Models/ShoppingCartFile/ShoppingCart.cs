using E_Commerce.Models.UserFile;

namespace E_Commerce.Models.ShoppingCartFile
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<ShoppingCartItems>? ShoppingCartItems { get; set; } = new HashSet<ShoppingCartItems>();
    }
}
