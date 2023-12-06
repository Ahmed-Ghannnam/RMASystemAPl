
using RMASystem.DAL;

namespace RMASystem.BL
{
    public interface IReceivedRequestsManager
    {
        Task AddAsync(ReceivedRequests entity);
        Task UpdateAsync(ReceivedRequests entity);
    }
}
