namespace E_Commerce.Models.User
{
    public class UserAddresses
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("UserAddress")]
        public int AdressId { get; set; }
        public bool IsDefault { get; set; }
        public User User { get; set; }

        public UserAddress? UserAddress { get; set; }
    }
}
