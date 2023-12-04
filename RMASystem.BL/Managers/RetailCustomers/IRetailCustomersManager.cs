using RMASystem.DAL;

namespace RMASystem.BL
{
    public interface IRetailCustomersManager
    {
     //   List<RetailCustomerReadDto> GetAll();
        RetailCustomers? GetByPhone(string phone);
        Task<int> Add(RetailCustomerAddDto entity);
        bool Update(RetailCustomerAddDto entity);
        Task<List<CustomerPointsReadSPDto>?> GetLoyaltyPoints(string? PhoneNo, OutputParameter<int>? returnValue = null, CancellationToken cancellationToken = default);
    }
}
