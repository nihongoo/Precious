using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Precious.Controller
{
	[Route("[controller]")]
	[ApiController]
	public class ImagesController : ControllerBase
	{
		private readonly Cloudinary _cloudinary;

		public ImagesController(Cloudinary cloudinary)
		{
			_cloudinary = cloudinary;
		}

		[HttpGet("Get-Image")]
		public async Task<IActionResult> FetchImages(string folderName)
		{
			try
			{
				var res = _cloudinary.ListResourcesByAssetFolder(folderName);
				return Ok(res);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Lỗi tải hình ảnh: " + ex.Message);
			}
		}
	}
}