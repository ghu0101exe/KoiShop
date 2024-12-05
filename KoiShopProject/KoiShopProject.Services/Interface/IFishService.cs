using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiShopProject.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KoiShopProject.Services.Interface
{
	public interface IFishService
	{
		Task<Fish> GetFishById(int id);
		Boolean DeleteFish(int id);
		Boolean UpdateFish(Fish fish);
		Boolean AddFish(Fish fish);

		Task<List<Fish>> GetAllFishs();
		Task<List<Fish>> GetFishByType(int idCategory);
		Task<List<Koifishcategory>> KoiCategoryList();
	}
}
