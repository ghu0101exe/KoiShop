using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiShopProject.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KoiShopProject.Repositories.Interface
{
	public interface ICustomerRepository
	{
		Task<Customer> GetCustomerById(int id);
		Boolean AddCustomer(Customer customer);
		Boolean UpdateCustomer(Customer customer);
		Boolean DeleteCustomer(int id);

		Task<List<Customer>> GetAllCustomers();
		Task<List<Order>> order();
	}
}
