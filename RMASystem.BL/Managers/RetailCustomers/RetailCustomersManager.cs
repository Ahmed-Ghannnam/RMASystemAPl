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

        public async Task<RetailCustomers?> GetByPhone(string phone)
        {
            return await _retailCustomerRepo.GetByPhone(phone);
        }

        public async Task<int> Add(RetailCustomerAddDto RetailCustomerDto)
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
            await _retailCustomerRepo.Add(RetailCustomersToAdd);
            await _retailCustomerRepo.SaveChanges();
            return RetailCustomersToAdd.Id;
        }

        public async Task<bool> Update(RetailCustomerAddDto RetailCustomerDto)
        {
           var RetailCustomerFromDB = await _retailCustomerRepo.GetByPhone(RetailCustomerDto.Phone);

            RetailCustomerFromDB!.CardCode = RetailCustomerDto.Code;
            RetailCustomerFromDB.NameL1 = RetailCustomerDto.Name;
            RetailCustomerFromDB.Phone = RetailCustomerDto.Phone;
            RetailCustomerFromDB.Address = RetailCustomerDto.Address;
            RetailCustomerFromDB.BirthDate = RetailCustomerDto.BirthDate;
            RetailCustomerFromDB.Email = RetailCustomerDto.Email;
            RetailCustomerFromDB.GENDER = RetailCustomerDto.Gender.ToLower() == "female" ? "F" : "M";

            _retailCustomerRepo.Update(RetailCustomerFromDB);
            await _retailCustomerRepo.SaveChanges();
            return true;
        }

        public async Task<List<CustomerPointsReadSPDto>?> GetLoyaltyPoints(string? PhoneNo, OutputParameter<int>? returnValue, CancellationToken cancellationToken)
        {
            return await _retailCustomerRepo.GetLoyaltyPoints(PhoneNo, returnValue, cancellationToken); //line 57
        }

    }
}
