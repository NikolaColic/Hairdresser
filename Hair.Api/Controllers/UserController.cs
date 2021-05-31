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
    /// WEB API Controller for user 
    /// </summary>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Produces("application/json")]
    [Route("hair/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGeneric<User> _generic;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="generic"></param>
        public UserController(IGeneric<User> generic)
        {
            this._generic = generic;
        }
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>Returns a list of users</returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
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
        /// <summary>
        /// Find user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return user filter by id</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
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
        /// <summary>
        /// Add new user OAUTH
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Return a list of users</returns>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> Add([FromBody] User user)
        {
            try
            {
                if(user is null)
                {
                    return BadRequest();
                }
                var response = await _generic.Add(user);
                if (!response) return NotFound();
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Update user 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns>Return user by id</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> Update(int id, [FromBody] User user)
        {
            try
            {
                if (id <= 0 || user is null)
                {
                    return BadRequest();
                }
                var response = await _generic.Update(user);
                if (!response) return NotFound();
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return noContent if user was deleted</returns>
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
