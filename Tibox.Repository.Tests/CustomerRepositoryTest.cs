using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Repositorio;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private readonly IRepository _repository;
        public CustomerRepositoryTest()
        {
            _repository = new Repositorio.Repository();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _repository.GetAllCustomer();
            Assert.AreEqual(result.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Customer()
        {
            var customer = new Models.Customer
            {
                FirstName = "Edwin",
                LastName = "Sanchez",
                City = "Trujillo",
                Country = "Peru",
                Phone = "555-555-555"
            };

            var result = _repository.InsertCustomer(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = _repository.GetCustomerById(92);
            Assert.AreEqual(customer != null, true);
            Assert.AreEqual(_repository.DeleteCustomer(customer), true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var customer = _repository.GetCustomerById(92);
            Assert.AreEqual(customer!=null, true);
            Assert.AreEqual(_repository.UpdateCustomer(customer), true);
        }
    }
}
