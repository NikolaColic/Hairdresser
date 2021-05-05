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
    [Route("hair/favourite")]
    [ApiController]
    public class FavouriteHairdresserController : ControllerBase
    {
        private readonly IGeneric<FavouriteHairdresser> _generic;
        public FavouriteHairdresserController(IGeneric<FavouriteHairdresser> generic)
        {
            this._generic = generic;
        }
       
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] FavouriteHairdresser favouriteHairdresser)
        {
            try
            {
                if(favouriteHairdresser is null)
                {
                    return BadRequest();
                } 
                var response = await _generic.Add(favouriteHairdresser);
                if (!response) return NotFound();
                return Ok();

            }catch(Exception ex)
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
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
