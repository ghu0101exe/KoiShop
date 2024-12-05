using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KoiShopProject.Repositories.Entities;

namespace KoiShopProject.WebApplication.Pages.Blogs
{
    public class EditModel : PageModel
    {
        private readonly KoiShopProject.Repositories.Entities.KoiShopDbContext _context;

        public EditModel(KoiShopProject.Repositories.Entities.KoiShopDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Blogpost Blogpost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost =  await _context.Blogposts.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blogpost == null)
            {
                return NotFound();
            }
            Blogpost = blogpost;
           ViewData["CustomerId"] = new SelectList(_context.Staff, "StaffId", "Password");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Blogpost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogpostExists(Blogpost.BlogId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BlogpostExists(int id)
        {
            return _context.Blogposts.Any(e => e.BlogId == id);
        }
    }
}
