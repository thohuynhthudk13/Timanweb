using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMAN.Model
{
   public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //tự tăng
        public int Id { set; get; }
        [Required(ErrorMessage = "Bạn phải nhập giá")]
        public decimal Price { set; get; }
        public DateTime DateCreated { set; get; }
        [MaxLength(250, ErrorMessage = "Tối đa 250 ký tự")]
        [Required(ErrorMessage = "Bạn phải nhập tên")]
        public string Name { set; get; }
        [MaxLength(500, ErrorMessage = "Tối đa 500 ký tự")]
        public string Description { set; get; }
        [Required(ErrorMessage = "Bạn phải nhập link hình ảnh")]
        public string ThumbnailImage { get; set; }
        [Required(ErrorMessage = "Bạn phải chọn loại sản phẩm")]
        public int CategoryId { set; get; }
        [ForeignKey("CategoryId")]
        public Category Category { set; get; }
    }
}
