namespace E_Commerce.Models
{
    public class ProductItemReview
    {
        public int Id { get; set; }
        public int OrederLineId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }

    }
}
