//using RMASystem.APIs.Data.Classes;
//using RMASystem.APIs.Data;
//using RMASystem.APIs.Data.Log;
////using RMAAPI.Areas.HelpPage.ModelDescriptions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;

//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http.Json;
//using RMASystem.APIs.Repos.Customer;
//using Microsoft.AspNetCore.Authorization;
//using RMAAPI.Models.Customer;
//using System.Text.Json;
//using RMASystem.APIs.Repos;

//namespace RMASystem.APIs.Controllers.Customer
//{
//    [Authorize]
//    [Route("api/Customer")]
//    [ApiController]

//    public class RetailCustomerController : ControllerBase
//    {
//        private const string logSource = "RetailCustomerController";

//        [AllowAnonymous]
//        [HttpPut]
//        [Route("retail_customer")]
//        public Task<IActionResult> CreateOrUpdateRetailCustomer(RetailCustomerBindingModel model)
//        {
//            APIReceivedRequests apiRequest = (APIReceivedRequests)HttpContext.Items["API_REQUEST_LOG"];
//            //apiRequest.USER_NAME = User.Identity.Name;
//            apiRequest.UpdateAPI_RECEIVED_REQUEST();

//            //if (!SecurityUsers.CheckUserExistanceAndPermission(User.Identity.Name, "Create & update retail customers"))
//            //    return Task.FromResult<IActionResult>(Unauthorized());

//            if (!ModelState.IsValid)
//            {
//                //foreach (KeyValuePair<string, System.Web.Http.ModelBinding.ModelState> state in ModelState)
//                //{
//                //    // TODO: Update article as not success
//                //}
//                return Task.FromResult<IActionResult>(BadRequest(ModelState));
//            }

//            if (model.Email.IsNotNull() && !Misc.IsMailAddressValid(model.Email))
//                return Task.FromResult<IActionResult>(BadRequest("Invalid email address"));

//            RetailCustomers rCust = new RetailCustomers(model.Phone);
//            rCust.CardCode = model.Code;
//            rCust.NameL1 = model.Name;
//            rCust.Phone = model.Phone;
//            rCust.Address = model.Address;
//            rCust.BirthDate = model.BirthDate;
//            rCust.Email = model.Email;
//            rCust.GENDER = model.Gender.ToLower() == "female" ? "F" : "M";
//            //rCust.InsertUID = User.Identity.Name;

//            try
//            {
//                if (rCust.Id.IsNull() || rCust.Id == 0)
//                    rCust.InsertRetailCustomers();
//                else
//                    rCust.UpdateRetailCustomers();
//            }
//            catch (Exception ex)
//            {
//                return Task.FromResult<IActionResult>(BadRequest(ex.Message));
//            }

//            return Task.FromResult<IActionResult>(Ok());
//        }

//        [AllowAnonymous]
//        [HttpGet]
//        [Route("retail_customer_points")]
//        public Task<IActionResult> GetRetailCustomerPoints(string phoneNo)
//        {
//            APIReceivedRequests apiRequest = (APIReceivedRequests)HttpContext.Items["API_REQUEST_LOG"];
//            //apiRequest.USER_NAME = User.Identity.Name;
//            apiRequest.UpdateAPI_RECEIVED_REQUEST();

//            //if (!SecurityUsers.CheckUserExistanceAndPermission(User.Identity.Name, "Get retail customers points"))
//            //    return Task.FromResult<IActionResult>(Unauthorized());



//            if (phoneNo.IsNull())
//                return Task.FromResult<IActionResult>(BadRequest("Invalid phone number"));
//            try
//            {
//                decimal points = 0;
//                decimal amount = 0;
//                RetailCustomers.GetRetailCustomerLoyaltyPointsDetails(out points, out amount, phoneNo: phoneNo);
//                Dictionary<string, decimal> pointsDict = new Dictionary<string, decimal>();
//                pointsDict.Add("Points", points);
//                pointsDict.Add("Amount", amount);
//                return Task.FromResult<IActionResult>(new JsonResult(pointsDict, RMASystem.APIs.Repos.Classes.Misc.SERIALIZER_SETTINGS));
//            }
//            catch (Exception ex)
//            {
//                LogHelper.Log(logSource, LogTarget.File, ex, "GetRetailCustomerPoints");
//                return Task.FromResult<IActionResult>(BadRequest(ex.Message));
//            }

//        }
//    }
//}
