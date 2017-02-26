using System.Collections.Generic;
using Tibox.Models;

namespace Tibox.Repositorio
{
    public interface IRepository
    {
        int InsertCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        Customer GetCustomerById(int id);

        IEnumerable<Customer> GetAllCustomer();
    }
}
