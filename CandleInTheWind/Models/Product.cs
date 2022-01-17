using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandleInTheWind.Models
{
    public class Product
    {
        [Display(Name = "Mã sản phẩm")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống.")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "money")]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "Đơn giá phải là một số không nhỏ hơn 0.")]
        [Display(Name = "Đơn giá")]
        [DisplayFormat(DataFormatString = "{0:0,0 VNĐ}")]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression("[0-9]+", ErrorMessage = "Số lượng trong kho phải là một số không nhỏ hơn 0.")]
        [Display(Name = "Số lượng trong kho")]
        public int Stock { get; set; }

        public string ImageUrl { get; set; }

        [NotMapped]
        [Display(Name = "Hình ảnh")]
        public IFormFile Image { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage="Bạn cần chọn một trong các hạng mục cho trước.")]
        public int CategoryId { get; set; }
        [Display(Name = "Hạng mục sản phẩm")]
        public virtual Category Category { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
