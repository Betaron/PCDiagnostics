namespace PCDiagnostics.Core.Domains.Devices.Repositories;

public interface IDeviceRepository
{
	Task<IEnumerable<Device>> GetAllWithDiagnosticIdAsync(Guid diagnosticId, CancellationToken cancellationToken);

	Task CreateAsync(Device device, CancellationToken cancellationToken);

	Task UpdateAsync(Device device, Guid diagnosticId, string name, CancellationToken cancellationToken);

	Task DeleteAsync(Guid diagnosticId, string name, CancellationToken cancellationToken);

	Task<bool> ExistsByPK(Guid diagnosticId, string name, CancellationToken cancellationToken);
}
