namespace E_Commerce.Models.Payment
{
    public class UserPaymentMethod
    {
        public int Id { get; set; }
        public int PaymentTypeId { get; set; }
        public int UserId { get; set; }
        public string Provider { get; set; }
        public int AccountNumber { get; set; }
        public DateOnly ExpireDate { get; set; }
        public bool IsDefault { get; set; }
    }
}
