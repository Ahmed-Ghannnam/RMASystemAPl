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

        public async Task InvokeAsync(HttpContext context)
        {
            
                var UserNameFromClaims = context.User.FindFirstValue(ClaimTypes.Name);
            var _apiRequest = new ReceivedRequests();
            // for this error message Unable to resolve service from root(middelware), you have to use lines of code below  instead of injecting in constructor or Create obj
            using (var scope = context.RequestServices.CreateScope())
            {
               // var _apiRequest = scope.ServiceProvider.GetRequiredService<ReceivedRequests>();
                var _receivedRequestsManager = scope.ServiceProvider.GetRequiredService<IReceivedRequestsManager>();

                
                _apiRequest.UserName = UserNameFromClaims ?? string.Empty;
                _apiRequest.ReceivedDate = DateTime.Now;
                _apiRequest.ApiUrl = context.Request.Path.ToString().ToLower();
                _apiRequest.RequestMethod = context.Request.Method;

                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering(); // Enable buffering so the body can be read multiple times through pipeline context

                    string body = await new System.IO.StreamReader(context.Request.Body).ReadToEndAsync();
                    if (!string.IsNullOrEmpty(body))
                        _apiRequest.Body = body;

                    context.Request.Body.Position = 0;  // Reset the position so other components can read the body
                }

                 _apiRequest.SetApiType();

                try
                {
                   await _receivedRequestsManager.AddAsync(_apiRequest);
                }
                catch
                {
                    throw;
                }
            }
            await _next(context);
        }
    }
}
