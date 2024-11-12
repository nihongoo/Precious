using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class CartController : ControllerBase
	{
		private readonly AllService<Cart> _allService;
        public CartController(AllService<Cart> allService)
        {
			_allService = allService;
        }

		[HttpPost("Create-Cart")]
		public async Task<IActionResult> Create(CartViewModel cart)
		{
			var data = new Cart()
			{
				IDCart = Guid.NewGuid(),
				CreateTime = DateTime.Now,
				Total = 0,
				Status = "1"
			};
			data.IDCustomer = data.IDCart;
			var result = await _allService.Add(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		[HttpPut("Edit-Cart")]
		public async Task<IActionResult> Update(CartViewModel Cart)
		{
			var data = new Cart()
			{
				IDCart = Cart.IDCart,
				CreateTime = Cart.CreateTime,
				Total = Cart.Total,
				Status = Cart.Status,
				IDCustomer = Cart.IDCustomer
			};
			var result = await _allService.Update(data);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

		[HttpDelete("Delete-Cart")]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var result = await _allService.Delete(Id);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
	}
}
