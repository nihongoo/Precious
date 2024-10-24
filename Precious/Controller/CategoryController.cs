using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly AllService<Category> _allService;

		/// <summary>
		/// contructor
		/// </summary>
		/// <param name="service"></param>
		public CategoryController(AllService<Category> service)
		{
			_allService = service;
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <returns></returns>
		[HttpGet("Get-All-Category")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _allService.GetAll());
		}

		/// <summary>
		/// Get a record by id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet("Get-By-ID-Category")]
		public async Task<IActionResult> GetByID(Guid Id)
		{
			return Ok(await _allService.GetAsync(Id));
		}

		/// <summary>
		/// create new record
		/// </summary>
		/// <param name="Category"></param>
		/// <returns></returns>
		[HttpPost("Create-Category")]
		public async Task<IActionResult> Create(CategoryViewModel Category)
		{
			var data = new Category()
			{
				IDCategory = Guid.NewGuid(),
				Name = Category.Name,
				Status = 1
			};
			var result = await _allService.Add(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// update a record
		/// </summary>
		/// <param name="Category"></param>
		/// <returns></returns>
		[HttpPut("Edit-Category")]
		public async Task<IActionResult> Update(CategoryViewModel Category)
		{
			var data = new Category()
			{
				IDCategory = Category.id,
				Name = Category.Name,
				Status = Category.Status
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
		[HttpDelete("Delete-Category")]
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
