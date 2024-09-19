using E_Commerce.Models.Product;

namespace E_Commerce.Models.Favourite
{
    public class FavouriteListItems
    {
        public int FavouriteListId { get; set; }
        [ForeignKey("Product")]
        public int ProductItemId { get; set; }
        public Product_Item? Product { get; set; }
    }
}
