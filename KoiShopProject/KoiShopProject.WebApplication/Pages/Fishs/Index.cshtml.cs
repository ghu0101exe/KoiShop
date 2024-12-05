using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Services.Interface;
using KoiShopProject.Services;

namespace KoiShopProject.WebApplication.Pages.Fishs
{
	public class IndexModel : PageModel
    {
	    private readonly IFishService _fishService;
        
        public IndexModel(IFishService fishService)
        {
            _fishService = fishService;
        }

		//public IList<Fish> Fish { get;set; } = default!;
		public List<Fish> Fish { get; set; }
		public List<Koifishcategory> KoiCategoryList { get; set; }

		[BindProperty(SupportsGet = true)]
		public int SelectedCategoryId { get; set; }
		public async Task OnGetAsync()
        {
			//Fish = await _service.GetAllFishs();
			KoiCategoryList = await _fishService.KoiCategoryList();
			if (SelectedCategoryId > 0)
			{
				Fish = await _fishService.GetFishByType(SelectedCategoryId);
			}
			else
			{
				Fish = await _fishService.GetAllFishs();
			}
		}
    }
}
