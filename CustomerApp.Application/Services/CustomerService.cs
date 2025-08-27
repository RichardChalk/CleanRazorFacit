using CustomerApp.Domain;
using CustomerApp.Domain.Interfaces;

namespace CustomerApp.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        public CustomerService(ICustomerRepository repo) => _repo = repo;
        public Task<IEnumerable<Customer>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Customer?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task AddAsync(Customer customer) => _repo.AddAsync(customer);
        public Task UpdateAsync(Customer customer) => _repo.UpdateAsync(customer);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
