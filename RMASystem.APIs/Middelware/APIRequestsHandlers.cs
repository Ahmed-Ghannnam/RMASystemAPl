using Microsoft.AspNetCore.Identity;
using RMASystem.BL;
using RMASystem.DAL;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace RMASystem.APIs

{
    public class APIRequestsHandlers
    {
        private readonly RequestDelegate _next;

        public APIRequestsHandlers(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<ApplicationUser> userManager)
        {
            
                //ApplicationUser? userFromDb = await userManager.GetUserAsync(context.User);
                var UserNamee = context.User.FindFirstValue(ClaimTypes.Name);


            // for this error message Unable to resolve service from root(middelware), you need to do that instead of injecting in constructor or Create obj
            using (var scope = context.RequestServices.CreateScope())
            {
                var _apiRequest = scope.ServiceProvider.GetRequiredService<APIReceivedRequests>();
                var _receivedRequestsManager = scope.ServiceProvider.GetRequiredService<IReceivedRequestsManager>();

                
                _apiRequest.UserName = UserNamee ?? string.Empty;
                _apiRequest.ReceivedDate = DateTime.Now;
                _apiRequest.ApiUrl = context.Request.Path;
                _apiRequest.RequestMethod = context.Request.Method;

                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering(); // Enable buffering so the body can be read multiple times through pipeline context

                    string body = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();
                    if (!string.IsNullOrEmpty(body))
                        _apiRequest.Body = body;

                    context.Request.Body.Position = 0;  // Reset the position so other components can read the body
                }

                _receivedRequestsManager.Add(_apiRequest);
              //  context.Items["API_REQUEST_LOG"] = _apiRequest;
            }

            await _next(context);
        }
    }
}
