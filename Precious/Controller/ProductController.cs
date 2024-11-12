using CloudinaryDotNet;
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
        private readonly AllService<Product> _service;

        public ProductController(ProductService service, AllService<Product> allService)
        {
            _productService = service;
            _service = allService;
        }

        /// <summary>
        /// image = publicId
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("Create-Product")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO product)
        {
            var result = await _productService.AddProduct(product.Product, product.ProductDetails);
			if (result.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

        [HttpGet("Get-All-Product")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpDelete("Delete-Product")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var delImg = await _productService.DeleteImg(id);
            var result = await _service.Delete(id);
			if (result.k && delImg.k) return Ok(result.msg);
			else return BadRequest(result.msg);
		}

        [HttpGet("Search")]
		public async Task<IActionResult> Search(string query, bool isSearchWithName)
		{
            if (isSearchWithName)
            {
				var result = await _service.Search(query, "Name");
				return Ok(result);
			}
            else
            {
				var result = await _service.Search(query, "ProductCode");
				return Ok(result);
			}
		}

        [HttpPost("Add-To-Cart")]
        public async Task<IActionResult> AddToCart(Guid productDetailId, int quantity, Guid UserId)
        {
            var result = await _productService.AddToCart(productDetailId, quantity, UserId);
            if (result.k) return Ok(result.msg);
            else return BadRequest(result.msg);
        }
	}
}
