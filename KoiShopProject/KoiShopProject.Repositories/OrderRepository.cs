using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

namespace KoiShopProject.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly KoiShopDbContext _context;
        public OrderRepository(KoiShopDbContext context)
        {
            _context = context;
        }
        public bool CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public bool DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByCustomerId(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByDateRange(DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByPaymentMethod(string paymentMethod)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByStaffId(int staffId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrdersByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetTotalOrderAmount(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalOrderCount()
        {
            throw new NotImplementedException();
        }

        public bool UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
