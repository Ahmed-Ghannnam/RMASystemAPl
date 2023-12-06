using RMASystem.DAL;
using System.Numerics;

namespace RMASystem.DAL
{
    public interface IRetailCustomersRepo
    {
        IEnumerable<RetailCustomers> GetAll();
        Task<RetailCustomers?> GetByPhoneAsync(string phone);
       // GetRetailCustomerLoyaltyPointsDetails
        Task AddAsync(RetailCustomers entity);
        void Update(RetailCustomers entity);
        void Delete(RetailCustomers entity);
        Task<int> SaveChangesAsync();
        Task<List<CustomerPointsReadSPDto>?> GetLoyaltyPointsAsync(string? PhoneNo, OutputParameter<int>? returnValue , CancellationToken cancellationToken = default);

    }
}
