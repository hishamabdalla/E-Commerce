using  E_Commerce.Models.OrderFile;


namespace E_Commerce.Models.User
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
    }
}
