
namespace RMASystem.DAL

{
    public class APIReceivedRequests
    {
        public int Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime ReceivedDate { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int ApiType { get; set; }
        public string ApiUrl { get; set; } = string.Empty;
        public string RequestMethod { get; set; } = string.Empty;

    }
    public enum API_TYPE
    {
        REGISTER = 0,
        GET_TOKEN = 1,
        CHANGE_PASSWORD = 2,
        CREATE_ARTICLE = 3,
        GET_PRODUCT_INFO = 4,
        UPDATE_PRODUCT_AS_SYNCED = 5,
        CREATE_UPDATE_RETAIL_CUSTOMER = 6,
        GET_RETAIL_CUSTOMER_POINTS = 7,
    }

}
