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
    public class DetailsModel : PageModel
    {
        private readonly IFishService _fishService;

        public DetailsModel(IFishService fishService)
        {
            _fishService = fishService;
        }

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
            else
            {
                Fish = fish;
            }
            return Page();
        }
    }
}
