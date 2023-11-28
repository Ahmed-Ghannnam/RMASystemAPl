using RMASystem.DAL;
using System.Numerics;

namespace RMASystem.DAL
{
    public interface IRetailCustomersRepo
    {
        IEnumerable<RetailCustomers> GetAll();
        RetailCustomers? GetByPhone(string phone);
       // GetRetailCustomerLoyaltyPointsDetails
        void Add(RetailCustomers entity);
        void Update(RetailCustomers entity);
        void Delete(RetailCustomers entity);
        int SaveChanges();
    }
}
