namespace E_Commerce.Models.UserFile
{
    public class UserAddresses
    {
        public int UserId { get; set; }
        public int AdressId { get; set; }
        public bool IsDefault { get; set; }
        public virtual User? User { get; set; }

        public virtual UserAddress? UserAddress { get; set; }
    }
}
