using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Services.Interface;
using KoiShopProject.Services;

namespace KoiShopProject.WebApplication.Pages.Fishs
{
    public class CreateModel : PageModel
    {
        private readonly IFishService _fishService;

        public CreateModel(IFishService fishService)
        {
            _fishService = fishService;
        }
        [BindProperty]
        public Fish Fish { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            var categories = await _fishService.KoiCategoryList();
            ViewData["IdCategory"] = new SelectList(categories, "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Nếu model không hợp lệ, load lại danh sách category và trả về trang
                var categories = await _fishService.KoiCategoryList();
                ViewData["IdCategory"] = new SelectList(categories, "Id", "Name");
                return Page();
            }

            // Thêm cá mới
            var result = _fishService.AddFish(Fish);

            if (!result)
            {
                // Xử lý khi thêm thất bại
                ModelState.AddModelError(string.Empty, "Failed to create fish");
                var categories = await _fishService.KoiCategoryList();
                ViewData["IdCategory"] = new SelectList(categories, "Id", "Name");
                return Page();
            }

            return RedirectToPage("./Index");
        }
        
    }
}
