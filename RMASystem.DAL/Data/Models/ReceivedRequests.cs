
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

        private static readonly Dictionary<string, API_TYPE> UrlToApiTypeMap = new()
        {
            { "/RetailCustomers/AddOrUpdate", API_TYPE.ADD_UPDATE_RETAIL_CUSTOMER },
            { "/RetailCustomers/GetLoyaltyPoints", API_TYPE.GET_RETAIL_CUSTOMER_LOYALTY_POINTS },
            { "/Users/register", API_TYPE.REGISTER },
            { "/Users/Login", API_TYPE.LOGIN },
            { "/Users/changePassword", API_TYPE.CHANGE_PASSWORD },
            { "/Users/RequestPasswordReset", API_TYPE.REQUEST_PASSWORD_RESET },
            { "/Users/ResetPassword", API_TYPE.RESET_PASSWORD },

        };

        public void SetApiType()
        {
            if (UrlToApiTypeMap.TryGetValue(ApiUrl, out var apiType))
            {
                ApiType = (int)apiType;
            }
            else
            {
                ApiType = (int)API_TYPE.UNKNOWN;
            }
        }

    }
    public enum API_TYPE
    {
        REGISTER = 0,
        LOGIN = 1,
        CHANGE_PASSWORD = 2,
        REQUEST_PASSWORD_RESET=3,
        RESET_PASSWORD= 4,
        ADD_UPDATE_RETAIL_CUSTOMER = 5,
        GET_RETAIL_CUSTOMER_LOYALTY_POINTS = 6,
        UNKNOWN = -1
    }

}
