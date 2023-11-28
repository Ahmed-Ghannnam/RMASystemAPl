using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.DAL
{
    public interface IReceivedRequestsRepo
    {
        void Add(APIReceivedRequests entity);
        void Update(APIReceivedRequests entity);
        int SaveChanges();


    }
}
