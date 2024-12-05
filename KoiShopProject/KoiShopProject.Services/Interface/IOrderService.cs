using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiShopProject.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KoiShopProject.Services.Interface
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int orderId);
        Boolean CreateOrder(Order order);
        Boolean UpdateOrder(Order order);
        Boolean DeleteOrder(int orderId);

        Task<List<Order>> GetAllOrders();
        Task<List<Order>> GetOrdersByCustomerId(int customerId);
        Task<List<Order>> GetOrdersByStaffId(int staffId);

        Task<List<Order>> GetOrdersByStatus(string status);
        Task<List<Order>> GetOrdersByDateRange(DateOnly startDate, DateOnly endDate);
        Task<List<Order>> GetOrdersByPaymentMethod(string paymentMethod);

        Task<int> GetTotalOrderCount();
        Task<decimal> GetTotalOrderAmount(int orderId);
    }
}
