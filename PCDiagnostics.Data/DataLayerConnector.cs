using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PCDiagnostics.Core;
using PCDiagnostics.Core.Domains.Devices.Repositories;
using PCDiagnostics.Core.Domains.Diagnostics.Repositories;
using PCDiagnostics.Core.Domains.User.Repositories;
using PCDiagnostics.Data.DbModels.Devices.Repositories;
using PCDiagnostics.Data.DbModels.Diagnostics.Repositories;
using PCDiagnostics.Data.DbModels.Users.Repositories;

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

		services.AddScoped<IDeviceRepository, DeviceRepository>();
		services.AddScoped<IDiagnosticRepository, DiagnosticRepository>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}
}
