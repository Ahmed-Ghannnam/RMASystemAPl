
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

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
           return _context.RetailCustomers.AsNoTracking();
        }

        public async Task<RetailCustomers?> GetByPhoneAsync(string phone)
        {
            return await _context.RetailCustomers.FirstOrDefaultAsync(x => x.Phone == phone);
        }
        public async Task AddAsync(RetailCustomers entity)
        {
            await _context.RetailCustomers.AddAsync(entity);

        }

        public void Update(RetailCustomers entity)
        {
            _context.RetailCustomers.Update(entity);
        }
        public void Delete(RetailCustomers entity)
        {
            _context.RetailCustomers.Remove(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
      

        public virtual async Task<List<CustomerPointsReadSPDto>?> GetLoyaltyPointsAsync(string? PhoneNo, OutputParameter<int>? returnValueOut = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
            new SqlParameter
            {
                ParameterName = "PhoneNo",
                Value = PhoneNo ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.NVarChar,
            },
            parameterreturnValue,
        };

            var ReadSPFromDB = 
                await _context.SqlQueryAsync<CustomerPointsReadSPDto>(
                    "EXEC @returnValue = [dbo].[GetRetailCustomerLoyaltyPoints] @PhoneNo",
                    sqlParameters, cancellationToken);

         //   returnValueOut?.SetValue(parameterreturnValue.Value);

            return ReadSPFromDB;
        }
    }
}
