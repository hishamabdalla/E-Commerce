namespace E_Commerce.Models.User
{
    public class UserAddress
    {
        public int Id { get; set; }

        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;

        public int? StreeNumber { get; set; }
        public string PostalCode { get; set; } = string.Empty;

        public int? UnitNumber { get; set; }

        [ForeignKey("Governorate")]
        public int GovernorateID { get; set; }

        public Governorate Governorate { get; set; }
    }
}
