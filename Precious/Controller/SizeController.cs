using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class SizeController : ControllerBase
	{
		private readonly AllService<Size> _allService;

		/// <summary>
		/// contructor
		/// </summary>
		/// <param name="service"></param>
		public SizeController(AllService<Size> service)
		{
			_allService = service;
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <returns></returns>
		[HttpGet("Get-All-Size")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _allService.GetAll());
		}

		/// <summary>
		/// Get a record by id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet("Get-By-ID-Size")]
		public async Task<IActionResult> GetByID(Guid Id)
		{
			return Ok(await _allService.GetAsync(Id));
		}

		/// <summary>
		/// create new record
		/// </summary>
		/// <param name="Size"></param>
		/// <returns></returns>
		[HttpPost("Create-Size")]
		public async Task<IActionResult> Create(SizeViewModel Size)
		{
			var data = new Size()
			{
				IDSize = Guid.NewGuid(),
				Name = Size.Name,
				Status = 1
			};
			var result = await _allService.Add(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// update a record
		/// </summary>
		/// <param name="Size"></param>
		/// <returns></returns>
		[HttpPut("Edit-Size")]
		public async Task<IActionResult> Update(SizeViewModel Size)
		{
			var data = new Size()
			{
				IDSize = Size.IDSize,
				Name = Size.Name,
				Status = Size.Status
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
		[HttpDelete("Delete-Size")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var result = await _allService.Delete(Id);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
	}
}
