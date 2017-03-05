using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repositorio;
using Tibox.Repositorio.Northwind;

namespace Tibox.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        IOrderRepository Orders { get; }
        IRepository<Order> Orderss { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Product > Products { get; }
        IRepository<Supplier> Suppliers { get; }
    }
}
