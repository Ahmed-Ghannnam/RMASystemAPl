using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RMASystem.BL;
using RMASystem.DAL;

namespace RMASystem.APIs.Controllers
{
    [Route("api/[controller]")]
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
        //[HttpGet("GetLoyaltyPoints")]
        //public IActionResult GetLoyaltyPoints(int cusId, string phoneNo)
        //{
        //    var results = _context.YourDbContext.FromSqlRaw("EXEC GetRetailCustomerLoyaltyPoints @CusID, @PhoneNo",
        //                        new SqlParameter("@CusID", cusId),
        //                        new SqlParameter("@PhoneNo", phoneNo))
        //                        .FirstOrDefault();

        //    if (results == null)
        //    {
        //        return NotFound();
        //    }

        //    var loyaltyPointsDto = new LoyaltyPointsDto
        //    {
        //        PointsBalance = results.PointsBalance,
        //        PointsAmount = results.PointsAmount
        //    };

        //    return Ok(loyaltyPointsDto);
        //}


        [HttpPut]
        [Authorize]
        public async Task<ActionResult> AddOrUpdate(RetailCustomerAddDto RetailCustomerDto)
        {
            try
            {

                if (RetailCustomerDto is null)
                {
                    return BadRequest(new GeneralResponse { Message = "Invalid request payload." });
                }

                var RetailCustomerFromDB =  _RetailCustomersManger.GetByPhone(RetailCustomerDto.Phone);

                if (RetailCustomerFromDB is null)
                {
                    _RetailCustomersManger.Add(RetailCustomerDto);
                    return Ok(new GeneralResponse { Message = "Created successfully" });
                }
                else
                {
                    _RetailCustomersManger.Update(RetailCustomerDto);
                    return Ok(new GeneralResponse { Message = "Updated successfully" });
                }

              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                return StatusCode(500, new GeneralResponse { Message = "An error occurred while processing the request." });
                throw;
            }
        }




    }
}
