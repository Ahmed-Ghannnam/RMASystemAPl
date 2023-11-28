using Microsoft.EntityFrameworkCore;
using RMASystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.BL 
{
    public class ReceivedRequestsManager : IReceivedRequestsManager
    {
        private readonly IReceivedRequestsRepo _receivedRequestsRepo;

        public ReceivedRequestsManager(IReceivedRequestsRepo receivedRequestsRepo)
        {
            _receivedRequestsRepo = receivedRequestsRepo;
        }

        public void Add(APIReceivedRequests entity)
        {
            _receivedRequestsRepo.Add(entity);
            _receivedRequestsRepo.SaveChanges();

        }



        public void Update(APIReceivedRequests entity)
        {
            _receivedRequestsRepo.Update(entity);
            _receivedRequestsRepo.SaveChanges();    
        }

    }
}
