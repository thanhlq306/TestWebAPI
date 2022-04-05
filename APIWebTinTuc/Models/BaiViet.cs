using System;

namespace APIWebTinTuc.Models
{
    public class BaiVietND
    {
        public string TenBaiViet { get; set; }
        public string TenTacGia { get; set; }
        public string ChuDe { get; set; }
        public string NoiDung { get; set; }
        public string GhiChu { get; set; } 
        public string TheLoai { get; set; }
    }

    public class BaiViet : BaiVietND
    {
        public Guid MaBaiViet { get; set; }


    }
}
