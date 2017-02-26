using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repositorio
{
    public class Repository : IRepository
    {
        private readonly string _connectionString;

        //ctor para agregar constructor
        public Repository()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["NorthwindConnectionString"]
                .ConnectionString;
        }

        public bool DeleteCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return  connection.Delete(customer);
            }
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<Customer>();
            }
        }

        public Customer GetCustomerById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<Customer>(id);
            }
        }

        public int InsertCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(customer);
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Update(customer);
            }
        }
    }
}
