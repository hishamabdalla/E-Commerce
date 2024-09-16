namespace E_Commerce.Models.OrderFile
{
    public class OrderLine
    {
        public int Id { get; set; }

        public int ProductItemId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
