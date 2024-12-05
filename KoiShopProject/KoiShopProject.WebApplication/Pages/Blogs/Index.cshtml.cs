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
    public class IndexModel : PageModel
    {
        private readonly KoiShopProject.Repositories.Entities.KoiShopDbContext _context;

        public IndexModel(KoiShopProject.Repositories.Entities.KoiShopDbContext context)
        {
            _context = context;
        }

        public IList<Blogpost> Blogpost { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Blogpost = await _context.Blogposts
                .Include(b => b.Customer).ToListAsync();
        }
    }
}
