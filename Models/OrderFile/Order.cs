using E_Commerce.Models.Payment;
using E_Commerce.Models.UserFile;

namespace E_Commerce.Models.OrderFile
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("UserPaymentMethod")]
        public int PaymentMethodId { get; set; }

        public int UserId { get; set; }

        public int AddressId { get; set; }

        public int TaxId { get; set; }

        public int ImportancyId { get; set; }

        public int OrderStatusId { get; set; }

        public DateOnly OrderDate { get; set; }

        public double TotalPrice { get; set; }

        public virtual ICollection<OrderLine>? OrderLines { get; set; } = new HashSet<OrderLine>();
        public virtual User? User { get; set; }
        public virtual UserPaymentMethod? UserPaymentMethod { get; set; }
        public virtual UserAddress? UserAddress { get; set; }
        public virtual OrderStatus? OrderStatus { get; set; }
        public virtual OrderImportancy? OrderImportancy { get; set; }
        public virtual Tax? Tax { get; set; }

    }
}
