namespace PCDiagnostics.Core.Domains.Devices.Repositories;

public interface IDeviceRepository
{
	Task<Device> GetByIdAsync(Guid id, CancellationToken cancellationToken);

	Task<IEnumerable<Device>> GetAllAsync(CancellationToken cancellationToken);

	Task CreateAsync(Device device, CancellationToken cancellationToken);

	Task UpdateAsync(Device device, CancellationToken cancellationToken);

	Task DeleteAsync(Guid id, CancellationToken cancellationToken);

	Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken);
}
