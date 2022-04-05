using APIWebTinTuc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using APIWebTinTuc.Data;

namespace APIWebTinTuc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietController : ControllerBase
    {
        private readonly MyDBcontext _context;

        public BaiVietController(MyDBcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bv = _context.dataBaiViets.ToList();
            return Ok(bv);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var baiviet = _context.dataBaiViets.SingleOrDefault(bv => bv.MaBaiViet == Guid.Parse(id));
            if (baiviet == null)
            {
                return NotFound();
            }
            return Ok(baiviet);
        }

        [HttpPost]
        
        public IActionResult Create(BaiVietND baivietnd)
        {
            var baiviet = new DataBaiViet
            {
                MaBaiViet = Guid.NewGuid(),
                TenBaiViet = baivietnd.TenBaiViet,
                TenTacGia = baivietnd.TenTacGia,
                NoiDung = baivietnd.NoiDung,
                ChuDe = baivietnd.ChuDe,
                GhiChu = baivietnd.GhiChu,
                //TheLoai = baivietnd.TheLoai
                TheLoai = baivietnd.TheLoai
            };
            _context.Add(baiviet);
            _context.SaveChanges();
            return Ok(new
            {
                Success = true , Data = baiviet
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, BaiVietND editBV)
        {

            var baiviet = _context.dataBaiViets.SingleOrDefault(bv => bv.MaBaiViet == Guid.Parse(id));
            if (baiviet == null)
            {
                return NotFound();
            }
            if (id != baiviet.MaBaiViet.ToString())
            {
                return BadRequest();
            }

            baiviet.TenBaiViet = editBV.TenBaiViet;
            baiviet.TenTacGia = editBV.TenTacGia;
            baiviet.NoiDung = editBV.NoiDung;
            baiviet.ChuDe = editBV.ChuDe;
            baiviet.GhiChu = editBV.GhiChu;
            baiviet.TheLoai = editBV.TheLoai;
            //baiviet.TheLoai = editBV.TheLoai;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            var baiviet = _context.dataBaiViets.SingleOrDefault(bv => bv.MaBaiViet == Guid.Parse(id));
            if (baiviet == null)
            {
                return NotFound();
            }
            _context.Remove(baiviet);
            _context.SaveChanges();
            return Ok();
        }
    }
}
