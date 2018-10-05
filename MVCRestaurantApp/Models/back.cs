namespace MVCRestaurantApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("back")]
    public partial class back
    {
        [Key]
        [Column(Order = 0)]
        public int delivery_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string meal_type { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cooking_mins { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "date")]
        public DateTime order_date { get; set; }
    }
}
