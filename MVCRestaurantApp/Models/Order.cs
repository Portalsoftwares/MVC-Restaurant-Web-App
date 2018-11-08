namespace MVCRestaurantApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int Order_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Customer_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        public int Menu_Id { get; set; }

        public int Quantity { get; set; }

        public virtual Menu Menu { get; set; }
    }
}
