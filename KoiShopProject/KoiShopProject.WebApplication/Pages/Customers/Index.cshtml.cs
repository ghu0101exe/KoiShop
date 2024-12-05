using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Services.Interface;

namespace KoiShopProject.WebApplication.Pages.Customers
{
    public class IndexModel : PageModel
    {
        //private readonly ICustomerService _customerService;

        //public IndexModel(ICustomerService customerService)
        //{
        //	_customerService = customerService;
        //}

        ////public IList<Fish> Fish { get;set; } = default!;
        //public List<Customer> Customer { get; set; } = default!;


        //      [BindProperty(SupportsGet = true)]
        //public int SelectedCategoryId { get; set; }
        //public async Task OnGetAsync()
        //{
        //	Customer = await _customerService.GetAllCustomers();

        //} 

        private readonly ICustomerService _customerService;

        public IndexModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public List<Customer> Customer { get; set; }
        public List<Order> OrderList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedOrderId { get; set; }

        public async Task OnGetAsync()
        {
            OrderList = await _customerService.order();
            if (SelectedOrderId > 0)
            {
                
                Customer = await _customerService.GetAllCustomers();
            }
            else
            {
                Customer = await _customerService.GetAllCustomers();
            }
        }
    }
}
