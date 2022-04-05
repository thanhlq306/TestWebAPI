using APIWebTinTuc.Data;
using APIWebTinTuc.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIWebTinTuc.Services
{
    public class LoaiBVsResponsi : LoaiBVResponsi
    {

        private readonly MyDBcontext _context;

        public LoaiBVsResponsi(MyDBcontext context)
        {
            _context = context;
        }

        public LoaiBVVM Add(Loai loai)
        {
            var _loai = new LoaiBaiViet()
            {
                TenLoai = loai.TenLoai
            };
            _context.Add(_loai);
            _context.SaveChanges();

            return new LoaiBVVM
            {
                Maloai = _loai.Maloai,
                TenLoai = _loai.TenLoai
            };
        }

        public void Del(int id)
        {
            var _loai = _context.dataLoais.SingleOrDefault(lo => lo.Maloai ==  id);
            if (_loai != null)
            {
                _context.Remove(_loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiBVVM> GetAll()
        {
            var loai = _context.dataLoais.Select(lo => new LoaiBVVM
            {
                Maloai = lo.Maloai,
                TenLoai = lo.TenLoai
            });
            return loai.ToList();
        }

        public LoaiBVVM GetById(int id)
        {
            var loai = _context.dataLoais.SingleOrDefault(lo => lo.Maloai == id);
            if (loai != null)
            {
                return new LoaiBVVM
                {
                    Maloai = loai.Maloai,
                    TenLoai = loai.TenLoai
                };
            }
            return null;
        }

        public void Update(LoaiBVVM loai)
        {
            var _loai = _context.dataLoais.SingleOrDefault(lo => lo.Maloai == loai.Maloai);
            _loai.TenLoai = loai.TenLoai;
            _context.SaveChanges();
        }
    }
}
