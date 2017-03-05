using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repositorio.Northwind
{
    public interface IOrderRepository : IRepository<Order>
    {
        Order OrderByOrderNumber(string order);
        Order OrderWithOrderItems(string order);
    }
}
