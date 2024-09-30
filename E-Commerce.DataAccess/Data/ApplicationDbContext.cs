﻿
using E_Commerce.Models.Favourite;
using E_Commerce.Models.OrderFile;
using E_Commerce.Models.Payment;
using E_Commerce.Models.Product;
using E_Commerce.Models.ShoppingCartFile;
using E_Commerce.Models.UserFile;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace E_Commerce.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
         : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAddress> UsersAddresses { get; set; }
        public DbSet<UserAddresses> UserAddressesList  { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItems> ShoppingCartItems { get; set; }
        public DbSet<CategoryPromotion> CategoryPromotions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<UserPaymentMethod>  UserPaymentMethods { get; set; }
        public DbSet<ProductItem> ProductItem { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderImportancy> OrderImportancies { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<ProductItemReview> ProductItemReviews  { get; set; }
        public DbSet<FavouriteListItems> FavouriteListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }




    }
}
