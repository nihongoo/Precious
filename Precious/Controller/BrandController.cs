using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly AllService<Brand> _allService;

		/// <summary>
		/// contructor
		/// </summary>
		/// <param name="service"></param>
        public BrandController(AllService<Brand> service)
        {
			_allService = service;
        }

		/// <summary>
		/// Get all
		/// </summary>
		/// <returns></returns>
		[HttpGet("Get-All-Brand")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _allService.GetAll());
		}

		/// <summary>
		/// Get a record by id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet("Get-By-ID-Brand")]
		public async Task<IActionResult> GetByID(Guid Id)
		{
			return Ok(await _allService.GetAsync(Id));
		}

		/// <summary>
		/// create new record
		/// </summary>
		/// <param name="brand"></param>
		/// <returns></returns>
		[HttpPost("Create-Brand")]
		public async Task<IActionResult> Create(BrandViewModel brand)
		{
			char firstLetter = brand.Name[0];
			Random random = new Random();
			string brandCode = firstLetter.ToString().ToUpper();

			for (int i = 0; i < 8; i++)
			{
				int digit = random.Next(0, 10);
				brandCode += digit.ToString();
			}
			var checkUnique = await _allService.CheckUnique("BrandCode", brandCode);
			if (checkUnique.k == false) return BadRequest(checkUnique.msg);
			var data = new Brand()
			{
				IDBrand = Guid.NewGuid(),
				BrandCode = brandCode,
				Name = brand.Name,
				Status = 1
			};
			var result = await _allService.Add(data);
			if(result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// update a record
		/// </summary>
		/// <param name="brand"></param>
		/// <returns></returns>
		[HttpPut("Edit-Brand")]
		public async Task<IActionResult> Update(BrandViewModel brand)
		{
			var data = new Brand()
			{
				IDBrand = brand.id,	
				BrandCode = brand.BrandCode,
				Name = brand.Name,
				Status = 1
			};
			var result = await _allService.Update(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// delete a record
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpDelete("Delete-Brand")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var result = await _allService.Delete(Id);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
		[HttpGet("Search")]
		public async Task<IActionResult> Search(string query)
		{
			var result = await _allService.Search(query, "Name");
			return Ok(result);
		}
	}
}
