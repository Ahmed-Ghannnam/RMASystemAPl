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

        public async Task AddAsync(ReceivedRequests entity)
        {
           await _receivedRequestsRepo.AddAsync(entity);
           await _receivedRequestsRepo.SaveChangesAsync();

        }



        public async Task UpdateAsync(ReceivedRequests entity)
        {
            _receivedRequestsRepo.Update(entity);
            await _receivedRequestsRepo.SaveChangesAsync();    
        }

    }
}
