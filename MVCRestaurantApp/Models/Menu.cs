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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Menu_Id { get; set; }

        [Required]
        [StringLength(50)] 
        [Display(Name ="Meal Name")]
        public string Meal_Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Type")]
        public string Meal_Type { get; set; }

        public int? Calories { get; set; }

        [Column(TypeName = "numeric")]
        [Range(0,1000, ErrorMessage ="Please enter an amount between 0 $ and 1000 $.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
