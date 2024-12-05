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

namespace KoiShopProject.WebApplication.Pages.Fishs
{
    public class EditModel : PageModel
    {
        private readonly IFishService _fishService;

        public EditModel(IFishService fishService)
        {
            _fishService = fishService;
        }

        [BindProperty]
        public Fish Fish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            int Id = (int)id;
            var fish = await _fishService.GetFishById(Id);

            if (fish == null)
            {
                return NotFound();
            }

            Fish = fish;

            // Load danh sách categories cho dropdown
            var categories = await _fishService.KoiCategoryList();
            ViewData["IdCategory"] = new SelectList(categories, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Reload categories khi validation fail
                var categories = await _fishService.KoiCategoryList();
                ViewData["IdCategory"] = new SelectList(categories, "Id", "Name");
                return Page();
            }

            var result = _fishService.UpdateFish(Fish);

            if (!result)
            {
                // Xử lý khi update thất bại
                ModelState.AddModelError(string.Empty, "Failed to update fish");
                var categories = await _fishService.KoiCategoryList();
                ViewData["IdCategory"] = new SelectList(categories, "Id", "Name");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
