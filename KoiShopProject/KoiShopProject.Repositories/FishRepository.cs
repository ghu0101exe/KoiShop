using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiShopProject.Repositories.Entities;
using KoiShopProject.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;

namespace KoiShopProject.Repositories
{
	public class FishRepository : IFishRepository
	{
		private readonly KoiShopDbContext _context;
		public FishRepository(KoiShopDbContext context)
		{
			_context = context;
		}

		public bool AddFish(Fish fish)
		{
			try
			{
				_context.Fish.Add(fish);
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		public bool DeleteFish(int id)
		{
			try
			{
				var fish = _context.Fish.FirstOrDefault(p => p.KoiId == id);
				if (fish != null)
				{
					_context.Fish.Remove(fish);
					_context.SaveChanges();
					return true;
				}
				return false;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		public async Task<List<Fish>> GetAllFishs()
		{
			return await _context.Fish.ToListAsync();
		}

		public async Task<Fish> GetFishById(int id)
		{
			return await _context.Fish.FirstOrDefaultAsync(p => p.KoiId == id);
		}


		public async Task<List<Fish>> GetFishByType(int idCategory)
		{
			return await _context.Fish.Where(f => f.IdCategory == idCategory).ToListAsync();
		}

		public async Task<List<Koifishcategory>> KoiCategoryList()
		{
			return await _context.Koifishcategories.ToListAsync();
		}

		public bool UpdateFish(Fish fish)
		{
			try
			{
				_context.Attach(fish).State = EntityState.Modified;
				_context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}
	}
}
