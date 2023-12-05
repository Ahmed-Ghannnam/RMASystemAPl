using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RMASystem.DAL;
using System.Security.Claims;

namespace RMASystem.APIs;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;

    public TestController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetSecuredData()
    {
        //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var UserName = User.FindFirstValue(ClaimTypes.Name);

        //Employee? userFromDb = await _userManager.FindByIdAsync(userId);

        ApplicationUser? userFromDb = await _userManager.GetUserAsync(User);

        return Ok(new
        {
            email = userFromDb?.Email,
            passwordHash = userFromDb?.PasswordHash,
            Message = "This is a secured endpoint. "
        });
    }

    [HttpGet]
    [Route("ForManagers")]
    [Authorize(Policy = "ManagersOnly")]
    public ActionResult GetSecuredDataForManager()
    {
        return Ok(new
        {
            Message = "This is a secured endpoint for managers Only."
        });
    }

    [HttpGet]
    [Route("ForEmployees")]
    [Authorize(Policy = "EmployeesOnly")]
    public ActionResult GetSecuredDataForEmployees()
    {
        return Ok(new
        {
            Message = "This is a secured endpoint for employees Only."
        });
    }

    [HttpGet]
    [Route("ForAll")]

    public ActionResult GetSecuredDataForAll()
    {
        return Ok(new
        {
            Message = "This is a secured endpoint for All."
        });
    }


    [HttpGet]
    [Route("ForAuth")]
    [Authorize]
    public ActionResult GetSecureDataForAll()
    {
        return Ok(new
        {
            Message = "This is a secured endpoint for Auth."
        });
    }
}
