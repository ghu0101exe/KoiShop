using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShopProject.Repositories.Entities;

namespace KoiShopProject.WebApplication.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly KoiShopProject.Repositories.Entities.KoiShopDbContext _context;

        public DetailsModel(KoiShopProject.Repositories.Entities.KoiShopDbContext context)
        {
            _context = context;
        }

        public Blogpost Blogpost { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _context.Blogposts.FirstOrDefaultAsync(m => m.BlogId == id);
            if (blogpost == null)
            {
                return NotFound();
            }
            else
            {
                Blogpost = blogpost;
            }
            return Page();
        }
    }
}
