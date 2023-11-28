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

        public RetailCustomers? GetByPhone(string phone)
        {
            return _retailCustomerRepo.GetByPhone(phone);
        }

        public int Add(RetailCustomerAddDto RetailCustomerDto)
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
            _retailCustomerRepo.Add(RetailCustomersToAdd);
            _retailCustomerRepo.SaveChanges();
            return RetailCustomersToAdd.Id;
        }

        public bool Update(RetailCustomerAddDto RetailCustomerDto)
        {
           var RetailCustomerFromDB = _retailCustomerRepo.GetByPhone(RetailCustomerDto.Phone);

            RetailCustomerFromDB.CardCode = RetailCustomerDto.Code;
            RetailCustomerFromDB.NameL1 = RetailCustomerDto.Name;
            RetailCustomerFromDB.Phone = RetailCustomerDto.Phone;
            RetailCustomerFromDB.Address = RetailCustomerDto.Address;
            RetailCustomerFromDB.BirthDate = RetailCustomerDto.BirthDate;
            RetailCustomerFromDB.Email = RetailCustomerDto.Email;
            RetailCustomerFromDB.GENDER = RetailCustomerDto.Gender.ToLower() == "female" ? "F" : "M";

            _retailCustomerRepo.Update(RetailCustomerFromDB);
            _retailCustomerRepo.SaveChanges();
            return true;
        }


    }
}
