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
    [Route("hair/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IGeneric<Reservation> _generic;
        public ReservationController(IGeneric<Reservation> generic)
        {
            this._generic = generic;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
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
        public async Task<ActionResult<Reservation>> GetById(int id)
        {
            try
            {
                if (id <= 0)
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
        public async Task<ActionResult<IEnumerable<Hairdresser>>> Add([FromBody] Reservation reservation)
        {
            try
            {
                if(reservation is null)
                {
                    return BadRequest();
                }
                var response = await _generic.Add(reservation);
                if (!response) return NotFound();
                return RedirectToRoute("GetAll");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Reservation>>> Update(int id, [FromBody] Reservation reservation)
        {
            try
            {
                if (id <= 0 || reservation is null)
                {
                    return BadRequest();
                }
                var response = await _generic.Update(reservation);
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
