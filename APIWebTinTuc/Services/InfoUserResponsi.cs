using APIWebTinTuc.Models;
using System.Collections.Generic;

namespace APIWebTinTuc.Services
{
    public interface InfoUserResponsi
    {
        List<UserModel> GetAll();
        UserModel GetById(int id);
        UserModel Add(UserModel us);
        void Update(UserModel us);
        void Del(int id);
    }
}
