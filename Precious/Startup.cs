using Microsoft.Extensions.Configuration;
using Precious.core.Extention;

namespace Precious
{
	public class Startup
	{
        public Startup(IConfiguration configuration)
        {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureService(IServiceCollection services)
		{
			services.AddExtentionsService(Configuration);
		}
    }
}
