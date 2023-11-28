
namespace RMASystem.DAL
{
    public class RetailCustomersRepo : IRetailCustomersRepo
    {
        private readonly RMAContext _context;

        public RetailCustomersRepo(RMAContext context)
        {
            _context = context;
        }

        public IEnumerable<RetailCustomers> GetAll()
        {
           return _context.RetailCustomers;
        }

        public RetailCustomers? GetByPhone(string phone)
        {
            return _context.RetailCustomers.FirstOrDefault(x => x.Phone == phone);
        }
        public void Add(RetailCustomers entity)
        {
            _context.RetailCustomers.Add(entity);

        }

        public void Update(RetailCustomers entity)
        {
            _context.RetailCustomers.Update(entity);
        }
        public void Delete(RetailCustomers entity)
        {
            _context.RetailCustomers.Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
