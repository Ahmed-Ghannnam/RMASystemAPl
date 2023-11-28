using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RMASystem.BL;
using RMASystem.DAL;

namespace RMASystem.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetailCustomersController : ControllerBase
    {
        private readonly IRetailCustomersManager _RetailCustomersManger;
        private readonly IReceivedRequestsManager _RecivedRequestsManager;
        private readonly ILogger<RetailCustomersController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public RetailCustomersController(IRetailCustomersManager RetailCustomersManger, ILogger<RetailCustomersController> logger, IReceivedRequestsManager receivedRequestsManager, UserManager<ApplicationUser> userManager)
        {
            _RetailCustomersManger = RetailCustomersManger;
            _logger = logger;
            _RecivedRequestsManager = receivedRequestsManager;
            _userManager = userManager;
        }
        //[HttpGet]
        //public ActionResult<List<RetailCustomers>> GetAll()
        //{
        //    return _RetailCustomersRepo.GetAll().ToList();
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
