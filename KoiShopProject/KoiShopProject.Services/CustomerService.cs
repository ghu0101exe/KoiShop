using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KoiShopProject.Services;
using KoiShopProject.Services.Interface;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Repositories.Interface;
using KoiShopProject.Repositories;

namespace KoiShopProject.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerService(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}
		public bool AddCustomer(Customer customer)
		{
			return _customerRepository.AddCustomer(customer);
		}

		public bool DeleteCustomer(int id)
		{
			return _customerRepository.DeleteCustomer(id);
		}

		public Task<List<Customer>> GetAllCustomers()
		{
			return _customerRepository.GetAllCustomers();
		}

		public Task<Customer> GetCustomerById(int id)
		{
			return _customerRepository.GetCustomerById(id);
		}

		public  Task<List<Order>> order()
		{
            try
            {
				return _customerRepository.order();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi không lấy được orderID (tại lớp Service): {ex.Message}", ex);
            }
        }

		public bool UpdateCustomer(Customer customer)
		{
			return _customerRepository.UpdateCustomer(customer);
		}
	}
}
