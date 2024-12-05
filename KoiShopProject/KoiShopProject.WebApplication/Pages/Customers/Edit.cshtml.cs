using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Services.Interface;
using KoiShopProject.Services;

namespace KoiShopProject.WebApplication.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public EditModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                return NotFound();
            }
            Id = (int)id;
            var customerId = await _customerService.GetCustomerById(Id);

            if (customerId == null)
            {
                return NotFound();
            }
            else
            {
                Customer = customerId;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = _customerService.UpdateCustomer(Customer);

            if (!result)
            {
                
                ModelState.AddModelError(string.Empty, "Failed to update customer");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
