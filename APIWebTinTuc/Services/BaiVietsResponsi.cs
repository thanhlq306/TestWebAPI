using APIWebTinTuc.Data;
using APIWebTinTuc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace APIWebTinTuc.Services
{
    public class BaiVietsResponsi : BaiVietResponsi
    {
        private readonly MyDBcontext _context;

        public BaiVietsResponsi(MyDBcontext context)
        {
            _context = context;
        }

        public BaiVietVM Add(BaiViet bv)
        {
            var _bv = new DataBaiViet()
            {
                TenBaiViet = bv.TenBaiViet,
                TenTacGia = bv.TenTacGia,
                NoiDung = bv.NoiDung,
                ChuDe = bv.ChuDe,
                GhiChu = bv.GhiChu,
                TheLoai = int.Parse(bv.TheLoai)
            };
            _context.Add(_bv);
            _context.SaveChanges();

            return new BaiVietVM
            {
                TenBaiViet = _bv.TenBaiViet,
                TenTacGia = _bv.TenTacGia,
                NoiDung = _bv.NoiDung,
                ChuDe = _bv.ChuDe,
                GhiChu = _bv.GhiChu,
                TheLoai = _bv.TheLoai
            };
        }

        public void Del(string id)
        {
            var _bv = _context.dataBaiViets.SingleOrDefault(bv => bv.MaBaiViet == Guid.Parse(id));
            if (_bv != null)
            {
                _context.Remove(_bv);
                _context.SaveChanges();
            }
        }

        public List<BaiVietVM> GetAll()
        {
            var _bv = _context.dataBaiViets.Select(bv => new BaiVietVM
            {
                MaBaiViet = bv.MaBaiViet,
                TenBaiViet = bv.TenBaiViet,
                TenTacGia = bv.TenTacGia,
                NoiDung = bv.NoiDung,
                ChuDe = bv.ChuDe,
                GhiChu = bv.GhiChu,
                TheLoai = bv.TheLoai
            });
            return _bv.ToList();
        }

        public BaiVietVM GetById(string id)
        {
            var _bv = _context.dataBaiViets.SingleOrDefault(bv => bv.MaBaiViet == Guid.Parse(id));
            if (_bv != null)
            {
                return new BaiVietVM
                {
                    MaBaiViet = _bv.MaBaiViet,
                    TenBaiViet = _bv.TenBaiViet,
                    TenTacGia = _bv.TenTacGia,
                    NoiDung = _bv.NoiDung,
                    ChuDe = _bv.ChuDe,
                    GhiChu = _bv.GhiChu,
                    TheLoai = _bv.TheLoai
                };
            }
            return null;
        }

        public void Update(BaiViet bv)
        {
            var _bv = _context.dataBaiViets.SingleOrDefault(bb => bb.MaBaiViet == bv.MaBaiViet);
            _bv.TenBaiViet = bv.TenBaiViet;
            _bv.TenTacGia = bv.TenTacGia;
            _bv.NoiDung = bv.NoiDung;
            _bv.ChuDe = bv.ChuDe;
            _bv.GhiChu = bv.GhiChu;
            _bv.TheLoai = int.Parse(bv.TheLoai);
            _context.SaveChanges();
        }
    }
}
