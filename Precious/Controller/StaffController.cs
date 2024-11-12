using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly StaffService _staffService;
		private readonly AllService<Staff> _allService;


        public StaffController(AllService<Staff> allService)
        {
			_staffService = new StaffService();
			_allService = allService;
        }

        //[Authorize]
        [HttpPost("/Create-New-Staff")]
		public async Task<IActionResult> CreateStaff(StaffViewModel staff)
		{
			var result = await _staffService.AddStaff(staff);
			if (result.k)
			{
				return Ok(result.msg);
			}
			else
			{
				return BadRequest(result.msg);
			}
		}
		/// <summary>
		/// Get all staff
		/// </summary>
		/// <returns></returns>
		[HttpGet("Get-All-Staff")]
		public async Task<IActionResult> GetAllStaff()
		{
			return Ok(await _allService.GetAll());
		}
		/// <summary>
		/// Search
		/// </summary>
		/// <param name="query"></param>
		/// <param name="isStaffCode"></param>
		/// <returns></returns>
		[HttpGet("Search")]
		public async Task<IActionResult> Search(string query, bool isStaffCode)
		{
			if (isStaffCode)
			{
				var result = await _allService.Search(query, "StaffCode");
				return Ok(result);
			}
			else
			{
				var result = await _allService.Search(query, "StaffName");
				return Ok(result);
			}
		}

		[HttpDelete("Delete-Staff")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var result = await _staffService.DeleteStaff(id);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
	}
}
