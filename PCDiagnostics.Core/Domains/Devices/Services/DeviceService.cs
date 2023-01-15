using PCDiagnostics.Core.Domains.Devices.Repositories;

namespace PCDiagnostics.Core.Domains.Devices.Services;

public class DeviceService : IDeviceService
{
	private readonly IDeviceRepository _deviceRepository;

	public DeviceService(IDeviceRepository deviceRepository)
	{
		_deviceRepository = deviceRepository;
	}

	public Task CreateAsync(Device device, CancellationToken cancellationToken)
	{
		return _deviceRepository.CreateAsync(device, cancellationToken);
	}

	public Task DeleteAsync(Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		return _deviceRepository.DeleteAsync(diagnosticId, name, cancellationToken);
	}

	public Task<bool> ExistsByPK(Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		return _deviceRepository.ExistsByPK(diagnosticId, name, cancellationToken);
	}

	public Task<IEnumerable<Device>> GetAllWithDiagnosticIdAsync(Guid diagnosticId, CancellationToken cancellationToken)
	{
		return _deviceRepository.GetAllWithDiagnosticIdAsync(diagnosticId, cancellationToken);
	}

	public Task UpdateAsync(Device device, Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		return _deviceRepository.UpdateAsync(device, diagnosticId, name, cancellationToken);
	}
}
