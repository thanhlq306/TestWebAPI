using APIWebTinTuc.Models;
using System.Collections.Generic;

namespace APIWebTinTuc.Services
{
    public interface BaiVietResponsi
    {
        List<BaiVietVM> GetAll();
        BaiVietVM GetById(string id);
        BaiVietVM Add(BaiViet bv);
        void Update(BaiVietVM bv);
        void Del(string id);
    }
}
