using RMASystem.DAL;


namespace RMASystem.BL
{
    public class RetailCustomersManager : IRetailCustomersManager
    {
        private readonly IRetailCustomersRepo _retailCustomerRepo;

        public RetailCustomersManager(IRetailCustomersRepo retailCustomerRepo)
        {
            _retailCustomerRepo = retailCustomerRepo;
        }

        public async Task<RetailCustomers?> GetByPhoneAsync(string phone)
        {
            return await _retailCustomerRepo.GetByPhoneAsync(phone);
        }

        public async Task<int> AddAsync(RetailCustomerAddDto RetailCustomerDto)
        {
            RetailCustomers RetailCustomersToAdd = new()
            {
                CardCode = RetailCustomerDto.Code,
                NameL1 = RetailCustomerDto.Name,
                Phone = RetailCustomerDto.Phone,
                Address = RetailCustomerDto.Address,
                BirthDate = RetailCustomerDto.BirthDate,
                Email = RetailCustomerDto.Email,
                GENDER = RetailCustomerDto.Gender.ToLower() == "female" ? "F" : "M",
                CustomerImage = Array.Empty<byte>()
            };
            await _retailCustomerRepo.AddAsync(RetailCustomersToAdd);
            await _retailCustomerRepo.SaveChangesAsync();
            return RetailCustomersToAdd.Id;
        }

        public async Task<bool> UpdateAsync(RetailCustomerAddDto RetailCustomerDto)
        {
           var RetailCustomerFromDB = await _retailCustomerRepo.GetByPhoneAsync(RetailCustomerDto.Phone);

            RetailCustomerFromDB!.CardCode = RetailCustomerDto.Code;
            RetailCustomerFromDB.NameL1 = RetailCustomerDto.Name;
            RetailCustomerFromDB.Phone = RetailCustomerDto.Phone;
            RetailCustomerFromDB.Address = RetailCustomerDto.Address;
            RetailCustomerFromDB.BirthDate = RetailCustomerDto.BirthDate;
            RetailCustomerFromDB.Email = RetailCustomerDto.Email;
            RetailCustomerFromDB.GENDER = RetailCustomerDto.Gender.ToLower() == "female" ? "F" : "M";

            _retailCustomerRepo.Update(RetailCustomerFromDB);
            await _retailCustomerRepo.SaveChangesAsync();
            return true;
        }

        public async Task<List<CustomerPointsReadSPDto>?> GetLoyaltyPointsAsync(string? PhoneNo, OutputParameter<int>? returnValue, CancellationToken cancellationToken)
        {
            return await _retailCustomerRepo.GetLoyaltyPointsAsync(PhoneNo, returnValue, cancellationToken); 
        }

    }
}
