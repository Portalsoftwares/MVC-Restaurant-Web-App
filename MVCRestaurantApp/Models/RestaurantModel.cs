namespace MVCRestaurantApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RestaurantModel : DbContext
    {
        public RestaurantModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
                .Property(e => e.Meal_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Meal_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Price)
                .HasPrecision(6, 2);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Customer_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Address)
                .IsUnicode(false);
        }
    }
}
