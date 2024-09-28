using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Precious.core.Service;
using Precious.Kh.Model;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

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
				"KhanhHoang",
				"928531516173692",
				"YMG2UIncBzLXz7CRi_Fl2-iIh98");

			var cloudinary = new CloudinaryDotNet.Cloudinary(cloudinaryAccount);
			services.AddSingleton(cloudinary);

			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
		}
		public static void UseExtensionsConfigure(this IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
		}
	}
}
