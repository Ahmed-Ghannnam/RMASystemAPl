using RMASystem.DAL;
using System.Numerics;

namespace RMASystem.DAL
{
    public interface IRetailCustomersRepo
    {
        IEnumerable<RetailCustomers> GetAll();
        RetailCustomers? GetByPhone(string phone);
       // GetRetailCustomerLoyaltyPointsDetails
        Task Add(RetailCustomers entity);
        void Update(RetailCustomers entity);
        void Delete(RetailCustomers entity);
        Task<int> SaveChanges();
        Task<List<CustomerPointsReadSPDto>?> GetLoyaltyPoints(string? PhoneNo, OutputParameter<int>? returnValue , CancellationToken cancellationToken = default);

        Task<RetailCustomers?> GetCustomerFromSP(string phone);
    }
}
