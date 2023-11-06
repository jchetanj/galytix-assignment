using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Galytix.WebApi.Services;

namespace Galytix.WebApi.Controllers
{
    [ApiController]
    [Route("api/gwp")]
    public class CountryGwpController : ControllerBase
    {
        private readonly IGwpService _gwpService;

        public CountryGwpController(IGwpService gwpService)
        {
            _gwpService = gwpService;
        }

        [HttpPost("avg")]
        public async Task<IActionResult> CalculateAverageGwp([FromBody] CountryGwpRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrWhiteSpace(request.Country) || request.LineOfBusiness == null || !request.LineOfBusiness.Any())
                {
                    return BadRequest("Invalid request data.");
                }

                var result = await _gwpService.CalculateAverageGwp(request.Country, request.LineOfBusiness);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
