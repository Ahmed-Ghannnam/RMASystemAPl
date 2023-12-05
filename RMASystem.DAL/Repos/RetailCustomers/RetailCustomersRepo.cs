
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
           return _context.RetailCustomers;
        }

        public async Task<RetailCustomers?> GetByPhone(string phone)
        {
            return await _context.RetailCustomers.FirstOrDefaultAsync(x => x.Phone == phone);
        }
        public async Task Add(RetailCustomers entity)
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

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
        public async Task<RetailCustomers?> GetCustomerFromSP (string phone)
        {
            return  await _context.RetailCustomers.FirstOrDefaultAsync(C => C.Phone == phone);
        }

        public virtual async Task<List<CustomerPointsReadSPDto>?> GetLoyaltyPoints(string? PhoneNo, OutputParameter<int>? returnValueOut = null, CancellationToken cancellationToken = default)
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

            var ReadSPFromDB = //line 75
                await _context.SqlQueryAsync<CustomerPointsReadSPDto>(
                    "EXEC @returnValue = [dbo].[GetRetailCustomerLoyaltyPoints] @PhoneNo",
                    sqlParameters, cancellationToken);

         //   returnValueOut?.SetValue(parameterreturnValue.Value);

            return ReadSPFromDB;
        }
    }
}
