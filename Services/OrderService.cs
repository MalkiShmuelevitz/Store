using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        IOrderRepository _iorderRepository;
        IProductRpository _iproductRepository;
        public OrderService(IOrderRepository iorderRepository, IProductRpository iproductRepository)
        {
            _iorderRepository = iorderRepository;
            _iproductRepository = iproductRepository;
        }

        public async Task<Order> Post(Order order)
        {
            bool check = await CheckOrderSum(order);
            if (!check) 
                return null;
            if (order.OrderItems.Count == 0)
                return null;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
            Order order1=await _iorderRepository.Post(order);
            return order1;
        }
        public async Task<Order> GetById(int id)
        {
            return await _iorderRepository.GetById(id);
        }

        public  async Task<bool> CheckOrderSum(Order order)
        {
            int? sum = 0;
            foreach (var item in order.OrderItems)
            {
                Product p = await _iproductRepository.GetById(item.ProductId);
                sum += p.Price;    
            }
           if(sum!=order.OrderSum)
                return false;
            return true;
        }
    }
}
