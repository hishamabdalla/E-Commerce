using E_Commerce.Models.Product;

namespace E_Commerce.Models.Favourite
{
    public class FavouriteListItems
    {
        [ForeignKey("FavouriteList")]
        public int FavouriteListId { get; set; }
        [ForeignKey("Products")]
        public int ProductItemId { get; set; }
        public Product_Item? Product { get; set; }
        public FavouriteList? FavouriteList { get; set; }
    }
}
