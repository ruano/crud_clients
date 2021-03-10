using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> FindByIdAsync(int id);
        Task<Customer> FindByNameAsync(string name);
        Task<List<Customer>> ListAsync();
        Task UpdateAsync(Customer customer);
        Task RemoveAsync(Customer customer);
    }
}