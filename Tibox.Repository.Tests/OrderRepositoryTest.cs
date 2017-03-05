using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.UnitOfWork;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderRepositoryTest()
        {
            _unitOfWork = new TiboxUnitOfWork();
        }
        
        [TestMethod]
        public void Customer_By_Orders()
        {
            var customer = _unitOfWork.Customers.CustomerWithOrders(20);
           
            Assert.AreEqual(customer != null, true);
            Assert.AreEqual(customer.Orders.Any(), true);
        }


        [TestMethod]
        public void Order_By_OrderNumber()
        {
            var order = _unitOfWork.Orders.OrderByOrderNumber("542397");
            
            Assert.AreEqual(order != null, true);

            Assert.AreEqual(order.Id, 20);
            Assert.AreEqual(order.OrderNumber, "542397");
            Assert.AreEqual(order.CustomerId, 25);

        }
        [TestMethod]
        public void Order_By_OrderItem()
        {
            var order = _unitOfWork.Orders.OrderWithOrderItems("542397");

            Assert.AreEqual(order != null, true);
            Assert.AreEqual(order.OrderItems.Any(), true);
        }
    }
}
