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

        public void Add(APIReceivedRequests entity)
        {
            _context.Add(entity);
        }

        public void Update(APIReceivedRequests entity)
        {
            _context.Update(entity);
        }
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
