using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Repositorio;
using Tibox.Models;
using Tibox.Repositorio.Northwind;
using Tibox.UnitOfWork;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerRepositoryTest()
        {
            _unitOfWork = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            var result = _unitOfWork.Customers.GetAll();
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
                Phone = "555-555-999"
            };

            var result = _unitOfWork.Customers.Insert(customer);
            Assert.AreEqual(result > 0, true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var customer = _unitOfWork.Customers.GetEntityById(1098);
            Assert.AreEqual(customer != null, true);
            Assert.AreEqual(_unitOfWork.Customers.Update(customer), true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = _unitOfWork.Customers.GetEntityById(102);
            Assert.AreEqual(customer != null, true);
            Assert.AreEqual(_unitOfWork.Customers.Delete(customer), true);
        }

        [TestMethod]
        public void Customer_By_Names()
        {
            var customer = _unitOfWork.Customers.SearchByNames("Maria", "Anders"); 

            //var result = _repository.SearchByNames("Maria", "Anders");
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Id, 1);
            Assert.AreEqual(customer.FirstName, "Maria");
            Assert.AreEqual(customer.LastName, "Anders");
        }

        [TestMethod]
        public void Customer_By_Orders()
        {
            var customer = _unitOfWork.Customers.CustomerWithOrders(7);

            //var result = _repository.SearchByNames("Maria", "Anders");
            Assert.AreEqual(customer != null, true);

            Assert.AreEqual(customer.Orders.Any(), true);
        }


    }
}
