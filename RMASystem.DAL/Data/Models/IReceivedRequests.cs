namespace RMASystem.DAL
{
    public interface IReceivedRequests
    {
        int Id { get; set; }
        string Body { get; set; }
        DateTime ReceivedDate { get; set; }
        string UserName { get; set; }
        int ApiType { get; set; }
        string ApiUrl { get; set; }
        string RequestMethod { get; set; }
    }
}