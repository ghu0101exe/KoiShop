using KoiShopProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiShopProject.Repositories.Interface
{
    public interface IOrderDetailService
    {
        Task<Orderdetail> GetOrderDetailById(int orderDetailId);
        Boolean CreateOrderDetail(Orderdetail orderDetail);
        Boolean UpdateOrderDetail(Orderdetail orderDetail);
        Boolean DeleteOrderDetail(int orderDetailId);

        Task<List<Orderdetail>> GetAllOrderDetails();
        Task<List<Orderdetail>> GetOrderDetailsByOrderId(int orderId);
        Task<List<Orderdetail>> GetOrderDetailsByKoiId(int koiId);

        Task<List<Orderdetail>> GetOrderDetailsByPromotionId(int promotionId);
        Task<decimal> CalculateOrderDetailTotal(int orderDetailId);

        Boolean CreateOrderDetails(List<Orderdetail> orderDetails);
        Task<decimal> CalculateOrderTotal(int orderId);
    }
}
