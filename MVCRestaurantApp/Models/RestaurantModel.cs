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
        public virtual DbSet<Recipe> Recipes { get; set; }

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
                .HasPrecision(4, 2);

            modelBuilder.Entity<Recipe>()
                .Property(e => e.Ingredients)
                .IsUnicode(false);

            modelBuilder.Entity<Recipe>()
                .Property(e => e.Cooking_Method)
                .IsUnicode(false);

            modelBuilder.Entity<Recipe>()
                .HasOptional(e => e.Menu)
                .WithRequired(e => e.Recipe);
        }
    }
}
