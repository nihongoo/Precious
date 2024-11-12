using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
		private readonly AllService<Customer> _allService;
		public AccountController(AllService<Customer> service)
		{
			_Service = new AccountService();
			_allService = service;
		}

		/// <summary>
		/// Login controller
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <returns></returns>
		[AllowAnonymous]
		[HttpGet("/login")]
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
		/// <summary>
		/// Get all User
		/// </summary>
		/// <returns></returns>
		[HttpGet("ALl-User")]
		public async Task<IActionResult> GetAllUser()
		{
			return Ok(await _allService.GetAll());
		}
		/// <summary>
		/// Search
		/// </summary>
		/// <param name="query"></param>
		/// <param name="isSearchEmail"></param>
		/// <returns></returns>
		[HttpGet("Search")]
		public async Task<IActionResult> Search(string query, bool isSearchEmail)
		{
			if (isSearchEmail)
			{
				var result = await _allService.Search(query, "Email");
				return Ok(result);
			}
			else
			{
				var result = await _allService.Search(query, "PhoneNumber");
				return Ok(result);
			}
		}
	}
}