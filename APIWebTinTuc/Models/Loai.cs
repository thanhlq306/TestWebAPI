using System.ComponentModel.DataAnnotations;

namespace APIWebTinTuc.Models
{
    public class Loai
    {
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
