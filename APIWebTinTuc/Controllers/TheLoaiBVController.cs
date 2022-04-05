using APIWebTinTuc.Data;
using APIWebTinTuc.Models;
using APIWebTinTuc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APIWebTinTuc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiBVController : ControllerBase
    {
        private readonly MyDBcontext _context;
        

        public TheLoaiBVController (MyDBcontext context)
        {
            _context = context;
        }

        

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dsLoai = _context.dataLoais.ToList();
                return Ok(dsLoai);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var dsLoai = _context.dataLoais.SingleOrDefault(loai => loai.Maloai == id);
                if (dsLoai == null)
                {
                    return NotFound();
                }
                return Ok(dsLoai);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        //[Authorize]
        public IActionResult CreateLoai(Loai model)
        {
            try
            {
                var loai = new LoaiBaiViet
                {
                    TenLoai = model.TenLoai
                };
                _context.Add(loai);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, loai);

            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateById(int id, Loai model)
        {
            var dsLoai = _context.dataLoais.SingleOrDefault(loai => loai.Maloai == id);
            if (dsLoai == null)
            {
                return NotFound();
            }
            dsLoai.TenLoai = model.TenLoai;
            _context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DelById(int id)
        {

            try
            {
                var dsLoai = _context.dataLoais.SingleOrDefault(loai => loai.Maloai == id);
                if (dsLoai == null)
                {
                    return NotFound();
                }
                _context.dataLoais.Remove(dsLoai);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
