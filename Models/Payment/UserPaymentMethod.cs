using E_Commerce.Models.OrderFile;
using E_Commerce.Models.UserFile;

namespace E_Commerce.Models.Payment
{
    public class UserPaymentMethod
    {
        public int Id { get; set; }
        [ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Provider { get; set; }
        public int AccountNumber { get; set; }
        public DateOnly ExpireDate { get; set; }
        public bool IsDefault { get; set; }
        public PaymentType? PaymentType { get; set; }
        public User? User { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
