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

        public virtual DbSet<back> backs { get; set; }
        public virtual DbSet<front> fronts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<back>()
                .Property(e => e.meal_type)
                .IsUnicode(false);

            modelBuilder.Entity<front>()
                .Property(e => e.meal_name)
                .IsUnicode(false);
        }
    }
}
