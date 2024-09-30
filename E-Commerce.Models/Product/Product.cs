﻿namespace E_Commerce.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        //[ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual ProductCategory? Category { get; set; }

        public virtual ICollection<ProductItem>? Items { get; set; } = new HashSet<ProductItem>();
    }
}
