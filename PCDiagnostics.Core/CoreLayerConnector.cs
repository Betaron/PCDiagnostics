using Microsoft.Extensions.DependencyInjection;
using PCDiagnostics.Core.Domains.Devices.Services;
using PCDiagnostics.Core.Domains.Diagnostics.Services;
using PCDiagnostics.Core.Domains.User.Services;

namespace PCDiagnostics.Core;

public static class CoreLayerConnector
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		services.AddScoped<IDeviceService, DeviceService>();
		services.AddScoped<IDiagnosticService, DiagnosticService>();
		services.AddScoped<IUserService, UserService>();
		return services;
	}
}
