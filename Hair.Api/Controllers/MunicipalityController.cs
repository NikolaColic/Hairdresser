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
    [Route("api/municipality")]
    [ApiController]
    public class MunicipalityController : ControllerBase
    {
        private readonly IGeneric<Municipality> _generic;
        public MunicipalityController(IGeneric<Municipality> generic)
        {
            this._generic = generic;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Municipality>>> GetAll()
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

    }
}
