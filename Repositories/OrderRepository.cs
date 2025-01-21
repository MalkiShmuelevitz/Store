using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        ManagerApiContext _managerApiContext;

        public OrderRepository(ManagerApiContext managerApiContext)
        {
            _managerApiContext = managerApiContext;
        }

        public async Task<Order> Post(Order order)
        {
            await _managerApiContext.Orders.AddAsync(order);
            await _managerApiContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetById(int id)
        {
           return await _managerApiContext.Orders.Include(o=>o.User).Include(o=>o.OrderItems).FirstOrDefaultAsync(o=>o.Id==id);
            
        }
    }
}
