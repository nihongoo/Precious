using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class SaleController : ControllerBase
	{
		private readonly AllService<Sale> _allService;

		/// <summary>
		/// contructor
		/// </summary>
		/// <param name="service"></param>
		public SaleController(AllService<Sale> service)
		{
			_allService = service;
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <returns></returns>
		[HttpGet("Get-All-Sale")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _allService.GetAll());
		}

		/// <summary>
		/// Get a record by id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet("Get-By-ID-Sale")]
		public async Task<IActionResult> GetByID(Guid Id)
		{
			return Ok(await _allService.GetAsync(Id));
		}

		/// <summary>
		/// create new record
		/// </summary>
		/// <param name="Sale"></param>
		/// <returns></returns>
		[HttpPost("Create-Sale")]
		public async Task<IActionResult> Create(SaleViewModel Sale)
		{
			var checkUnique = await _allService.CheckUnique("SaleCode", Sale.SaleCode);
			if (checkUnique.k == false) return BadRequest(checkUnique.msg);
			var data = new Sale()
			{
				IDSale = Guid.NewGuid(),
				SaleCode = Sale.SaleCode,
				Name = Sale.Name,
				Value = Sale.Value,
				StartDay = Sale.StartDay,
				EndDay = Sale.EndDay,
				Description = Sale.Description,
				Status = 1
			};
			var result = await _allService.Add(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// update a record
		/// </summary>
		/// <param name="Sale"></param>
		/// <returns></returns>
		[HttpPut("Edit-Sale")]
		public async Task<IActionResult> Update(SaleViewModel Sale)
		{
			var checkUnique = await _allService.CheckUnique("SaleCode", Sale.SaleCode);
			if (checkUnique.k == false) return BadRequest(checkUnique.msg);
			var data = new Sale()
			{
				IDSale = Sale.IDSale,
				SaleCode = Sale.SaleCode,
				Name = Sale.Name,
				Value = Sale.Value,
				StartDay = Sale.StartDay,
				EndDay = Sale.EndDay,
				Description = Sale.Description,
				Status = Sale.Status
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
		[HttpDelete("Delete-Sale")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var result = await _allService.Delete(Id);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
	}
}
