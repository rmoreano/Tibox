using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Tibox.Repositorio.Northwind;

namespace Tibox.Repositorio
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public Order OrderByOrderNumber(string order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", order);

                return connection.
                    QueryFirst<Order>("dbo.OrderSearchByOrderNumber",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public Order OrderWithOrderItems(string order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderNumber", order);

                using (var multiple = connection.QueryMultiple("dbo.OrderWithOrdersItems", parameters, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var orders = multiple.Read<Order>().Single();
                    orders.OrderItems = multiple.Read<OrderItem>();
                    return orders;
                }

            }
        }
    }
}
