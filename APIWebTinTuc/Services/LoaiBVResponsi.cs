using APIWebTinTuc.Models;
using System.Collections.Generic;

namespace APIWebTinTuc.Services
{
    public interface LoaiBVResponsi
    {
        List<LoaiBVVM> GetAll();
        LoaiBVVM GetById(int id);
        LoaiBVVM Add(Loai loai);
        void Update(LoaiBVVM loai);
        void Del(int id);
    }
}
