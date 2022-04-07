using APIWebTinTuc.Data;
using APIWebTinTuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace APIWebTinTuc.Services
{
    public class InfoUsersResponsi: InfoUserResponsi
    {
        private readonly MyDBcontext _context;

        public InfoUsersResponsi(MyDBcontext context)
        {
            _context = context;
        }

        public UserModel Add(UserModel us)
        {
            var _us = new User()
            {
                UserName = us.UserName,
                //PassWord = MD5Security(us.PassWord),
                PassWord = Sha256Crypt(us.PassWord),
                HoTen = us.HoTen,
                Email = us.Email
            };
            _context.Add(_us);
            _context.SaveChanges();

            return new UserModel
            {
                UserName = _us.UserName,
                PassWord =_us.PassWord,
                HoTen = _us.HoTen,
                Email = _us.Email
            };
        }

        //private string MD5Security(string passWord)
        //{
        //    MD5 mh = MD5.Create();
        //    //Chuyển kiểu chuổi thành kiểu byte
        //    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(passWord);
        //    //mã hóa chuỗi đã chuyển
        //    byte[] hash = mh.ComputeHash(inputBytes);
        //    //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
        //    StringBuilder sb = new StringBuilder();

        //    for (int i = 0; i < hash.Length; i++)
        //    {
        //        sb.Append(hash[i].ToString("X2"));
        //    }
        //    return sb.ToString();
        //}

        public string Sha256Crypt(string data)
        {
            
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));  
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void Del(int id)
        {
            var _us = _context.dataUsers.SingleOrDefault(us => us.Id == id);
            if (_us != null)
            {
                _context.Remove(_us);
                _context.SaveChanges();
            }
        }

        public List<UserModel> GetAll()
        {
            var _us = _context.dataUsers.Select(us => new UserModel
            {
                Id = us.Id,
                UserName = us.UserName,
                PassWord = us.PassWord,
                HoTen = us.HoTen,
                Email = us.Email,
            });
            return _us.ToList();
        }

        public UserModel GetById(int id)
        {
            var _us = _context.dataUsers.SingleOrDefault(us => us.Id == id);
            if (_us != null)
            {
                return new UserModel
                {
                    UserName = _us.UserName,
                    PassWord = _us.PassWord,
                    HoTen = _us.HoTen,
                    Email = _us.Email
                };
            }
            return null;
        }

        public void Update(UserModel us)
        {
            var _us = _context.dataUsers.SingleOrDefault(uss => uss.Id == us.Id);
            _us.UserName = us.UserName;
            //_us.PassWord = MD5Security(us.PassWord);
            _us.PassWord = Sha256Crypt(us.PassWord);
            _us.HoTen = us.HoTen;
            _us.Email = us.Email;

            _context.SaveChanges();
        }
    }
}
