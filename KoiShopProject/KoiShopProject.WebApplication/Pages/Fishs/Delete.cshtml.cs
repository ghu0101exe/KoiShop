using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Services.Interface;

namespace KoiShopProject.WebApplication.Pages.Fishs
{
    public class DeleteModel : PageModel
    {
        private readonly IFishService _fishService;

        public DeleteModel(IFishService fishService)
        {
            _fishService = fishService;
        }

        [BindProperty]
        public Fish Fish { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                return NotFound();
            }
            Id = (int)id;
            var fishId = await _fishService.GetFishById(Id);

            if (fishId == null)
            {
                return NotFound();
            }
            else
            {
                Fish = fishId;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            int Id = 0;
            if (id == null)
            {
                return NotFound();
            }
            Id = (int)id;
            _fishService.DeleteFish(Id);
            return RedirectToPage("./Index");
        }
    }
}
