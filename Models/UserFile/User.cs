using E_Commerce.Models.Favourite;
using  E_Commerce.Models.OrderFile;
using E_Commerce.Models.Payment;
using E_Commerce.Models.ShoppingCartFile;


namespace E_Commerce.Models.UserFile
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public int Age { get; set; }

        public virtual ICollection<UserAddresses>? UserAddresses { get; set; } = new HashSet<UserAddresses>();
        public virtual ICollection<Order>? Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<FavouriteList>? FavouriteLists { get; set; } = new HashSet<FavouriteList>();
        public virtual ICollection<UserPaymentMethod>? UserPaymentMethods { get; set; } = new HashSet<UserPaymentMethod>();
        public virtual ICollection<ShoppingCart>? ShoppingCarts { get; set; } = new HashSet<ShoppingCart>();
    }
}
