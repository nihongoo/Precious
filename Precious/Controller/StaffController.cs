using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly StaffService _staffService;

        public StaffController()
        {
			_staffService = new StaffService();
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
	}
}
