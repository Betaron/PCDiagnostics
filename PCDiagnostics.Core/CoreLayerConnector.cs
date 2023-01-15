using Microsoft.Extensions.DependencyInjection;

namespace PCDiagnostics.Core;

public static class CoreLayerConnector
{
	public static IServiceCollection AddCore(this IServiceCollection services)
	{
		return services;
	}
}
