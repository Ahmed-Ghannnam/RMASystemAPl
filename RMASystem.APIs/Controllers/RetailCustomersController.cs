using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RMASystem.BL;
using RMASystem.DAL;

namespace RMASystem.APIs.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RetailCustomersController : ControllerBase
    {
        private readonly IRetailCustomersManager _RetailCustomersManger;
        private readonly ILogger<RetailCustomersController> _logger;

        public RetailCustomersController(IRetailCustomersManager RetailCustomersManger, ILogger<RetailCustomersController> logger)
        {
            _RetailCustomersManger = RetailCustomersManger;
            _logger = logger;
        }

        [HttpPut("AddOrUpdate")]
        [Authorize]
        public async Task<ActionResult> AddOrUpdate(RetailCustomerAddDto RetailCustomerDto)
        {
            try
            {

                if (RetailCustomerDto is null)
                {
                    return BadRequest(new GeneralResponse { Message = "Invalid request payload." });
                }

                var RetailCustomerFromDB = await _RetailCustomersManger.GetByPhone(RetailCustomerDto.Phone);

                if (RetailCustomerFromDB is null)
                {
                   await _RetailCustomersManger.Add(RetailCustomerDto);
                    return Ok(new GeneralResponse { Message = "Created successfully" });
                }
                else
                {
                    await _RetailCustomersManger.Update(RetailCustomerDto);
                    return Ok(new GeneralResponse { Message = "Updated successfully" });
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, new GeneralResponse { Message = "An error occurred while processing the request." });
            }
        }

        [HttpGet("GetLoyaltyPoints")]
        [Authorize]
        public async Task<IActionResult> GetLoyaltyPoints(string phoneNo)
        {
            try
            {
                var results = await _RetailCustomersManger.GetLoyaltyPoints(phoneNo); 
                if (results == null)
                {
                    return NotFound();
                }

                return Ok(results);
            }
            catch 
            {
                throw;
                //  return StatusCode(500, new GeneralResponse { Message = "An error occurred while processing the request." });
            }



        }

        



      
    }

}
