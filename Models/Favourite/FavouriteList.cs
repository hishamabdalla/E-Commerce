using E_Commerce.Models.UserFile;

namespace E_Commerce.Models.Favourite
{
    public class FavouriteList
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        public virtual ICollection<FavouriteListItems>? FavouriteListItems { get; set; } = new HashSet<FavouriteListItems>();
        
    }
}
