namespace MVCRestaurantApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public int Menu_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Meal_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Meal_Type { get; set; }

        public int? Calories { get; set; }

        public decimal Price { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
