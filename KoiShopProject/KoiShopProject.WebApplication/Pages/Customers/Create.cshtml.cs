using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Services.Interface;

namespace KoiShopProject.WebApplication.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public CreateModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Thêm khách hàng mới
            var result = _customerService.AddCustomer(Customer);

            if (!result)
            {
                // Xử lý khi thêm thất bại
                ModelState.AddModelError(string.Empty, "Failed to create customer");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
