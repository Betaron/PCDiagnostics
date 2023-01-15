namespace PCDiagnostics.Core.Domains.Devices.Services;

public interface IDeviceService
{
	Task<Device> GetByIdAsync(Guid id, CancellationToken cancellationToken);

	Task<IEnumerable<Device>> GetAllAsync(CancellationToken cancellationToken);

	Task CreateAsync(Device device, CancellationToken cancellationToken);

	Task UpdateAsync(Device device, CancellationToken cancellationToken);

	Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
