
using RMASystem.DAL;

namespace RMASystem.BL
{
    public interface IReceivedRequestsManager
    {
        void Add(APIReceivedRequests entity);
        void Update(APIReceivedRequests entity);
    }
}
