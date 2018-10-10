namespace MVCRestaurantApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Recipe")]
    public partial class Recipe
    {
        [Key]
        public int Recipe_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Ingredients { get; set; }

        [Required]
        [StringLength(50)]
        public string Cooking_Method { get; set; }

        public int Cooking_Time { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
