using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShopProject.Repositories.Entities;

namespace KoiShopProject.WebApplication.Pages.Blogs
{
    public class CreateModel : PageModel
    {
        private readonly KoiShopProject.Repositories.Entities.KoiShopDbContext _context;

        public CreateModel(KoiShopProject.Repositories.Entities.KoiShopDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Staff, "StaffId", "Password");
            return Page();
        }

        [BindProperty]
        public Blogpost Blogpost { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Blogposts.Add(Blogpost);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
