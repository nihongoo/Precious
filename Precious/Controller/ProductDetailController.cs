using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.Controller
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductDetailController : ControllerBase
	{
		private readonly AllService<ProductDetail> _service;
        public ProductDetailController(AllService<ProductDetail> service)
        {
            _service = service;
        }

		[HttpGet("Get-All-Detail")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await _service.GetAll());
		}
    }
}
