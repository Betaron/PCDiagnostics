using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PCDiagnostics.Data;

public static class DataLayerConnector
{
	public static IServiceCollection AddData(
			this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<PCDiagnosticsContext>(options =>
		{
			options.UseNpgsql(configuration["Databases:PostgreSql"]);
			options.UseSnakeCaseNamingConvention();
		});

		return services;
	}
}
