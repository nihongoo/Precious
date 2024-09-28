using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class TagetCustomersController : ControllerBase
	{
		private readonly AllService<TagetCustomers> _allService;

		/// <summary>
		/// contructor
		/// </summary>
		/// <param name="service"></param>
		public TagetCustomersController(AllService<TagetCustomers> service)
		{
			_allService = service;
		}

		/// <summary>
		/// Get all
		/// </summary>
		/// <returns></returns>
		[HttpGet("Get-All-TagetCustomers")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _allService.GetAll());
		}

		/// <summary>
		/// Get a record by id
		/// </summary>
		/// <param name="Id"></param>
		/// <returns></returns>
		[HttpGet("Get-By-ID-TagetCustomers")]
		public async Task<IActionResult> GetByID(Guid Id)
		{
			return Ok(await _allService.GetAsync(Id));
		}

		/// <summary>
		/// create new record
		/// </summary>
		/// <param name="TagetCustomers"></param>
		/// <returns></returns>
		[HttpPost("Create-TagetCustomers")]
		public async Task<IActionResult> Create(TagetCustomersViewModel TagetCustomers)
		{
			var data = new TagetCustomers()
			{
				IDTagetCustomer = Guid.NewGuid(),
				Name = TagetCustomers.Name,
				Status = 1
			};
			var result = await _allService.Add(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		/// <summary>
		/// update a record
		/// </summary>
		/// <param name="TagetCustomers"></param>
		/// <returns></returns>
		[HttpPut("Edit-TagetCustomers")]
		public async Task<IActionResult> Update(TagetCustomersViewModel TagetCustomers)
		{
			var data = new TagetCustomers()
			{
				IDTagetCustomer = TagetCustomers.IDTagetCustomer,
				Name = TagetCustomers.Name,
				Status = TagetCustomers.Status
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
		[HttpDelete("Delete-TagetCustomers")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var result = await _allService.Delete(Id);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
	}
}
