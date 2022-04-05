using System;

namespace APIWebTinTuc.Models
{
    public class BaiVietVM
    {
        public Guid MaBaiViet { get; set; }
        public string TenBaiViet { get; set; }
        public string TenTacGia { get; set; }
        public string ChuDe { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; }
        public int TheLoai { get; set; }
    }
}
