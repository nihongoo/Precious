using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.IService;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly AccountService _Service;
        public AccountController()
        {
			_Service = new AccountService();
        }

		/// <summary>
		/// Login controller
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpPost("/login")]
		public async Task<IActionResult> LoginAsnyc(string username, string password)
		{
			var result = await _Service.Login(username, password);
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
		/// Customer sign up
		/// </summary>
		/// <param name="customer"></param>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpPost("/signup")]
		public async Task<IActionResult> SignUp(CustomerViewModel customer)
		{
			var result = await _Service.SignUp(customer);
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