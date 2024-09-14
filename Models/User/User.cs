using  E_Commerce.Models.OrderFile;


namespace E_Commerce.Models.User
{
    public class User
    {
        public int Id { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age { get; set; }

        public virtual ICollection<UserAddresses>? UserAddresses { get; set; }
        public virtual ICollection<Order>? Order {  get; set; }
    }
}
