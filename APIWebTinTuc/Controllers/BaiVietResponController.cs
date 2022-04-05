using APIWebTinTuc.Models;
using APIWebTinTuc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIWebTinTuc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaiVietResponController : ControllerBase
    {
        private readonly BaiVietResponsi _BVInterface;

        public BaiVietResponController(BaiVietResponsi BVResponsi)
        {
            _BVInterface = BVResponsi;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_BVInterface.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var dsBV = _BVInterface.GetById(id);
                if (dsBV == null)
                {
                    return NotFound();
                }
                return Ok(dsBV);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]

        public IActionResult Create(BaiViet baiviet)
        {
            try
            {
                return Ok(_BVInterface.Add(baiviet));

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, BaiViet editBV)
        {

            if (id.Equals(editBV.MaBaiViet))
            {
                return BadRequest();
            }
            try
            {

                _BVInterface.Update(editBV);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {

            try
            {
                _BVInterface.Del(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
