
namespace RMASystem.DAL

{
    public class ReceivedRequests 
    {
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime ReceivedDate { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int ApiType { get; set; }
        public string ApiUrl { get; set; } = string.Empty;
        public string RequestMethod { get; set; } = string.Empty;

        private static readonly Dictionary<string, Api_Type> UrlToApiTypeMapDic = new()
        {
            { "/retailcustomers/addorupdate", Api_Type.AddUpdateRetailCustomer },
            { "/retailcustomers/getloyaltyoints", Api_Type.GetRetailCustomerLoyaltyPoints },
            { "/users/register", Api_Type.Register },
            { "/users/login", Api_Type.Login },
            { "/users/changepassword", Api_Type.ChangePassword },
            { "/users/requestpasswordreset", Api_Type.RequestPasswordReset },
            { "/users/resetpassword", Api_Type.ResetPassword },

        };

        public void SetApiType()
        {
            if (UrlToApiTypeMapDic.TryGetValue(ApiUrl, out var apiType))
            {
                ApiType = (int)apiType;
            }
            else
            {
                ApiType = (int)Api_Type.Unknown;
            }
        }

    }
    public enum Api_Type
    {
        Register = 0,
        Login = 1,
        ChangePassword = 2,
        RequestPasswordReset = 3,
        ResetPassword = 4,
        AddUpdateRetailCustomer = 5,
        GetRetailCustomerLoyaltyPoints = 6,
        Unknown = -1
    }

}
