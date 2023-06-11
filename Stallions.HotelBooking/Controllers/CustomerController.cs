using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stallions.HotelBooking.Utils.DTO;
using System.IdentityModel.Tokens.Jwt;

namespace Stallions.HotelBooking.API.Controllers
{
    [Authorize(Policy = "Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpPost]
        [Route("CreateBooking")]
        public IActionResult CreateBooking([FromBody] CreateBookingRequest model)
        {
            return Ok(new
            {
                Result = true
            });
        }
    }
}
