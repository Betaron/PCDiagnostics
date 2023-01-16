using Microsoft.EntityFrameworkCore;
using PCDiagnostics.Data;

namespace PCDiagnostics.Web.HostedServices;

public class MigrationHostedService : IHostedService
{
	private readonly IServiceProvider _serviceProvider;

	public MigrationHostedService(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public Task StartAsync(CancellationToken cancellationToken)
	{
		using (var scope = _serviceProvider.CreateScope())
		{
			var context = scope.ServiceProvider.GetService<PCDiagnosticsContext>();

			if (context == null)
			{
				throw new Exception($"{nameof(PCDiagnosticsContext)} not registered");
			}

			context.Database.Migrate();
		}

		return Task.CompletedTask;
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}
