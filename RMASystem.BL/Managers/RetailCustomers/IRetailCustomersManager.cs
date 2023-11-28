using RMASystem.DAL;

namespace RMASystem.BL
{
    public interface IRetailCustomersManager
    {
     //   List<RetailCustomerReadDto> GetAll();
        RetailCustomers? GetByPhone(string phone);
        // GetRetailCustomerLoyaltyPointsDetails
        int Add(RetailCustomerAddDto entity);
        bool Update(RetailCustomerAddDto entity);
        //  void Delete(RetailCustomers entity);
    }
}
