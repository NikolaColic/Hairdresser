using Hair.Data.Entities;
using Hair.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hair.Api.Controllers
{
    [Route("api/hairdresser")]
    [ApiController]
    public class HairdresserController : ControllerBase
    {
        private readonly IGeneric<Hairdresser> _generic;
        public HairdresserController(IGeneric<Hairdresser> generic)
        {
            this._generic = generic;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Hairdresser>>> GetAll()
        {
            try
            {
                var response = await _generic.GetAll();
                if (response is null || !response.Any()) return NotFound();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hairdresser>> GetById(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest();
                }
                var response = await _generic.GetById(id);
                if (response is null) return NotFound();
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Hairdresser>>> Add([FromBody] Hairdresser hairdresser)
        {
            try
            {
                if(hairdresser is null)
                {
                    return BadRequest();
                }
                var response = await _generic.Add(hairdresser);
                if (!response) return NotFound();
                return RedirectToRoute("GetAll");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Hairdresser>>> Update(int id, [FromBody] Hairdresser hairdresser)
        {
            try
            {
                if(id <= 0 || hairdresser is null)
                {
                    return BadRequest();
                }
                var response = await _generic.Update(hairdresser);
                if (!response) return NotFound();
                return RedirectToRoute("GetAll");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }
                var response = await _generic.Delete(id);
                if (!response) return NotFound();
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
