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
    /// <summary>
    /// Web API Controller for favourite hairdresser
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [Route("hair/v1/favourite")]
    [ApiController]
    public class FavouriteHairdresserController : ControllerBase
    {
        private readonly IGeneric<FavouriteHairdresser> _generic;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="generic"></param>
        public FavouriteHairdresserController(IGeneric<FavouriteHairdresser> generic)
        {
            this._generic = generic;
        }
       
        /// <summary>
        /// Add favourite hairdresser for user
        /// </summary>
        /// <param name="favouriteHairdresser"></param>
        /// <returns>Return 200 ok if add favourite hairdresser</returns>
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

        /// <summary>
        /// Delete favourite hairdresser for user with that parametar id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Deleted </returns>
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
