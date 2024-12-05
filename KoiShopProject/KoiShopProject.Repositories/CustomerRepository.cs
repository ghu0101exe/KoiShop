using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

namespace KoiShopProject.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly KoiShopDbContext _context;
		public CustomerRepository(KoiShopDbContext context)
		{
			_context = context;
		}
		public bool AddCustomer(Customer customer)
		{
			try
			{
				_context.Customers.Add(customer);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		public bool DeleteCustomer(int id)
		{
			try
			{
				var customer = _context.Customers.Where(p => p.CustomerId.Equals(id)).FirstOrDefault();
				if (customer != null)
				{
					_context.Customers.Remove(customer);
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		public async Task<List<Customer>> GetAllCustomers()
		{
			return await _context.Customers.ToListAsync();
		}

		public async Task<Customer> GetCustomerById(int id)
		{
			return await _context.Customers.FirstOrDefaultAsync(p => p.CustomerId == id);
		}

		public async Task<List<Order>> order()
		{
            try
            {
                var orders = await _context.Orders
                    .Select(o => new Order { OrderId = o.OrderId })
                    .OrderBy(o => o.OrderId)
                    .ToListAsync();

                return orders;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không lấy được orderID (lớp Repository): {ex.Message}", ex);
            }
        }

		public bool UpdateCustomer(Customer customer)
		{
			try
			{
				_context.Attach(customer).State = EntityState.Modified;
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}
	}
}
