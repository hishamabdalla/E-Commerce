namespace E_Commerce.Models.OrderFile
{
    public class Order
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }

        public int UserId { get; set; }

        public int AddressId { get; set; }

        public int TaxId { get; set; }

        public int ImportancyId { get; set; }

        public string OrderStatus { get; set; }

        public DateOnly OrderDate { get; set; }

        public double TotalPrice { get; set; }
    }
}
