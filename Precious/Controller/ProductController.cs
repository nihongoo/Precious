using Microsoft.AspNetCore.Mvc;
using Precious.core.Models;
using Precious.core.Service;
using Precious.Kh.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly ProductService _productService;

        public ProductController(ProductService service)
        {
            _productService = service;
        }

        [HttpPost("Create-Product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            var result = await _productService.AddProduct(product.Product, product.ProductDetails);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}
    }
}
