using Shop.Models;

namespace Shop.Managers.Interfaces;

public interface ICustomerManager
{
    public Task<List<Customer>> GetAllCustomersAsync();
    public Task<Customer> GetCustomerByIdAsync(int id);
    public Task AddCustomerAsync(Customer customer);
    public Task UpdateCustomerAsync(Customer customer);
    public Task DeleteCustomerAsync(int id);
}