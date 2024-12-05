using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using KoiShopProject.Services;
using KoiShopProject.Services.Interface;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;


namespace KoiShopProject.Services
{
	public class FishService : IFishService
	{
		private readonly IFishRepository _fishRepository;

		public FishService(IFishRepository fishRepository)
		{
			_fishRepository = fishRepository;
		}

		public bool AddFish(Fish fish)
		{
			return _fishRepository.AddFish(fish);
		}

		public bool DeleteFish(int id)
		{
			return _fishRepository.DeleteFish(id);
		}

		public Task<List<Fish>> GetAllFishs()
		{
			return _fishRepository.GetAllFishs();
		}

		public Task<Fish> GetFishById(int id)
		{
			return _fishRepository.GetFishById(id);
		}

		public Task<List<Fish>> GetFishByType(int idCategory)
		{
			return _fishRepository.GetFishByType(idCategory);
		}

		public Task<List<Koifishcategory>> KoiCategoryList()
		{
			return _fishRepository.KoiCategoryList();
		}

		public bool UpdateFish(Fish fish)
		{
			return _fishRepository.UpdateFish(fish);
		}
	}
}
