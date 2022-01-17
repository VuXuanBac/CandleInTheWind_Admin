using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandleInTheWind.Models
{
    public class Category
    {
        [Display(Name = "Mã hạng mục")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name="Hạng mục sản phẩm")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
