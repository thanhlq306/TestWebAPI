using APIWebTinTuc.Models;
using APIWebTinTuc.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWebTinTuc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoUserController : ControllerBase
    {
        private readonly InfoUserResponsi _infoUserResponsi;

        // GET: api/<InfoUserController>

        public InfoUserController(InfoUserResponsi infoUserResponsi)
        {
            _infoUserResponsi = infoUserResponsi;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_infoUserResponsi.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            try
            {
                var dsUS = _infoUserResponsi.GetById(id);
                if (dsUS == null)
                {
                    return NotFound();
                }
                return Ok(dsUS);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
            [HttpPost]
        public IActionResult Create(UserModel us)
        {
            try
            {
                return Ok(_infoUserResponsi.Add(us));

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, UserModel us)
        {
            if (id == us.Id)
            {
                return BadRequest();
            }
            try
            {

                _infoUserResponsi.Update(us);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Del(int id)
        {
            try
            {
                _infoUserResponsi.Del(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
