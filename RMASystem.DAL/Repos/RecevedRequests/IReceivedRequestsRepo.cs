using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.DAL
{
    public interface IReceivedRequestsRepo
    {
        Task Add(ReceivedRequests entity);
        void Update(ReceivedRequests entity);
        Task<int> SaveChanges();


    }
}
