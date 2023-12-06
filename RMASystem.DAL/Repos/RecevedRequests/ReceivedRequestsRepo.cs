using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMASystem.DAL
{
    public class ReceivedRequestsRepo : IReceivedRequestsRepo
    {
        private readonly RMAContext _context;

        public ReceivedRequestsRepo(RMAContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ReceivedRequests entity)
        {
           await _context.AddAsync(entity);
        }

        public void Update(ReceivedRequests entity)
        {
            _context.Update(entity);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
