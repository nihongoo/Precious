using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Precious.core.Service;
using Precious.Kh.Model;

namespace Precious.core.Extention
{
	public static class StartupExtentions
	{
		public static void AddExtentionsService(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
			services.AddScoped(typeof(AllService<>));

			// Cấu hình Cloudinary
			var cloudinaryAccount = new CloudinaryDotNet.Account(
				"dtlxhfejw",
				"928531516173692",
				"YMG2UIncBzLXz7CRi_Fl2-iIh98");

			var cloudinary = new CloudinaryDotNet.Cloudinary(cloudinaryAccount);
			services.AddSingleton(cloudinary);
			services.AddScoped<ProductService>();
		}
	}
}
