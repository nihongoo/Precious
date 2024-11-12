using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class MeterialController : ControllerBase
	{
		private readonly AllService<Meterial> _allService;

		/// <summary>
		/// contructor
		/// </summary>
		/// <param name="service"></param>
		public MeterialController(AllService<Meterial> service)
		{
			_allService = service;
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <returns></returns>
		[HttpGet("Get-All-Meterial")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _allService.GetAll());
		}

		/// <summary>
		/// Get a record by id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet("Get-By-ID-Meterial")]
		public async Task<IActionResult> GetByID(Guid Id)
		{
			return Ok(await _allService.GetAsync(Id));
		}

		/// <summary>
		/// create new record
		/// </summary>
		/// <param name="Meterial"></param>
		/// <returns></returns>
		[HttpPost("Create-Meterial")]
		public async Task<IActionResult> Create(MeterialViewModel Meterial)
		{
			var data = new Meterial()
			{
				IDMeterial = Guid.NewGuid(),
				Name = Meterial.Name,
				Status = 1
			};
			var result = await _allService.Add(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// update a record
		/// </summary>
		/// <param name="Meterial"></param>
		/// <returns></returns>
		[HttpPut("Edit-Meterial")]
		public async Task<IActionResult> Update(MeterialViewModel Meterial)
		{
			var data = new Meterial()
			{
				IDMeterial = Meterial.id,
				Name = Meterial.Name,
				Status = Meterial.Status
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
		[HttpDelete("Delete-Meterial")]
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
