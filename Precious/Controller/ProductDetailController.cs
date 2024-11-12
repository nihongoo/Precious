using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductDetailController : ControllerBase
	{
		private readonly AllService<ProductDetail> _service;
		private readonly ProductDetailService _detailService;
        public ProductDetailController(AllService<ProductDetail> service, ProductDetailService detailService)
        {
			_detailService = detailService;
            _service = service;
        }
		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("Get-All-Detail")]
		public async Task<IActionResult> GetAll(Guid id)
		{
			return Ok(await _detailService.GetAll(id));
		}

		[HttpPut("Edit-Detail")]
		public async Task<IActionResult> Edit(ProductDetailViewModel detail)
		{
			var result = await _detailService.Update(detail);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
    }
}
