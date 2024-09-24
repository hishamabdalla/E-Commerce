using E_Commerce.Models.OrderFile;
using E_Commerce.Models.UserFile;

namespace E_Commerce.Models.Payment
{
    public class UserPaymentMethod
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        [MinLength(16)]
        public string AccountNumber { get; set; }
        public DateOnly ExpireDate { get; set; }
        public bool IsDefault { get; set; }




        //[ForeignKey("PaymentType")]
        public int PaymentTypeId { get; set; }
        //[ForeignKey("User")]
        public int UserId { get; set; }

        /// Navigation Properties
        public virtual PaymentType? PaymentType { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
