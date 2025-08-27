using CustomerApp.Domain;
using CustomerApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Infrastructure
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _db;
        public CustomerRepository(CustomerDbContext db) => _db = db;
        public async Task<IEnumerable<Customer>> GetAllAsync() => await _db.Customers.ToListAsync();
        public async Task<Customer?> GetByIdAsync(int id) => await _db.Customers.FindAsync(id);
        public async Task AddAsync(Customer customer)
        {
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Customer customer)
        {
            _db.Customers.Update(customer);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var c = await _db.Customers.FindAsync(id);
            if (c != null)
            {
                _db.Customers.Remove(c);
                await _db.SaveChangesAsync();
            }
        }
    }
}
