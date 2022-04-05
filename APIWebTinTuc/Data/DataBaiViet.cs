using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIWebTinTuc.Data
{
    [Table("BaiViet")]
    public class DataBaiViet
    {
        [Key]
        public Guid MaBaiViet { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenBaiViet { get; set; }
        public string TenTacGia { get; set; }
        public string ChuDe { get; set; }
        [MaxLength(2000)]
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }
        public int TheLoai { get; set; }
        [ForeignKey("TheLoai")]
        public LoaiBaiViet Loai { get; set; }
    }



}
