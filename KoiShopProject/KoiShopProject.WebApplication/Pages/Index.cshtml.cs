using KoiShopProject.Repositories.Entities;
using KoiShopProject.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShopProject.WebApplication.Pages
{
    //public class IndexModel : PageModel
    //{
    //	private readonly ILogger<IndexModel> _logger;

    //	public IndexModel(ILogger<IndexModel> logger)
    //	{
    //		_logger = logger;
    //	}

    //	public void OnGet()
    //	{

    //	}
    //}

    public class IndexModel : PageModel
    {
        private readonly IFishService _fishService;

        public IndexModel(IFishService fishService)
        {
            _fishService = fishService;
        }

        //public IList<Fish> Fish { get;set; } = default!;
        public List<Fish> FishList { get; set; }
        public List<Koifishcategory> KoiCategoryList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int SelectedCategoryId { get; set; }
        public async Task OnGetAsync()
        {
            //Fish = await _service.GetAllFishs();
            KoiCategoryList = await _fishService.KoiCategoryList();
            if (SelectedCategoryId > 0)
            {
                FishList = await _fishService.GetFishByType(SelectedCategoryId);
            }
            else
            {
                FishList = await _fishService.GetAllFishs();
            }
        }
    }
}
