using RMASystem.DAL;

namespace RMASystem.BL
{
    public interface IRetailCustomersManager
    {
     //   List<RetailCustomerReadDto> GetAll();
        Task<RetailCustomers?> GetByPhoneAsync(string phone);
        Task<int> AddAsync(RetailCustomerAddDto entity);
        Task<bool> UpdateAsync(RetailCustomerAddDto entity);
        Task<List<CustomerPointsReadSPDto>?> GetLoyaltyPointsAsync(string? PhoneNo, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default);
    }
}
