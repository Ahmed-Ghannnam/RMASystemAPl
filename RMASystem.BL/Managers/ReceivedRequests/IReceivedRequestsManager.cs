
using RMASystem.DAL;

namespace RMASystem.BL
{
    public interface IReceivedRequestsManager
    {
        Task Add(ReceivedRequests entity);
        Task Update(ReceivedRequests entity);
    }
}
