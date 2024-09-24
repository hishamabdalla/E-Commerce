namespace E_Commerce.Models.OrderFile
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
