namespace E_Commerce.Models.OrderFile
{
    public class OrderLine
    {
        public int Id { get; set; }

        public int ProductItenId { get; set; }

        public int OrderId { get; set; }

        public int QuantityOfItem { get; set; }

        public double Price { get; set; }
    }
}
