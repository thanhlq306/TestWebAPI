using APIWebTinTuc.Data;
using APIWebTinTuc.Models;
using APIWebTinTuc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebTinTuc.Controllers
{
    // Responsitory
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiBVResponController : ControllerBase
    {
        private readonly LoaiBVResponsi _loaiBVInterface;

        public LoaiBVResponController(LoaiBVResponsi loaiBVInterface)
        {
            _loaiBVInterface = loaiBVInterface;
        }

        // GET: api/<LoaiBVController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_loaiBVInterface.GetAll());
        }

        // GET api/<LoaiBVController>/5
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                var dsLoai = _loaiBVInterface.GetById(id);
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

        // POST api/<LoaiBVController>
        [HttpPost]
        public IActionResult Create(Loai loai)
        {
            try
            {
                return Ok(_loaiBVInterface.Add(loai));

            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<LoaiBVController>/5
        [HttpPut("{id}")]
        public IActionResult Update (int id, LoaiBVVM loai)
        {
            if (id != loai.Maloai)
            {
                return BadRequest();
            }
            try
            {
                
                _loaiBVInterface.Update(loai);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<LoaiBVController>/5
        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            try
            {
                _loaiBVInterface.Del(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
