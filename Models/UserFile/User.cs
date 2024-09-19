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

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public int Age { get; set; }

        public virtual ICollection<UserAddresses>? UserAddresses { get; set; }
        public virtual ICollection<Order>? Order {  get; set; }
        public ICollection<FavouriteList>? FavouriteLists { get; set; }
        public ICollection<UserPaymentMethod>? UserPaymentMethods { get; set; }
        public ICollection<ShoppingCart>? ShoppingCarts { get; set; }
    }
}
