using PCDiagnostics.Core.Domains.Devices.Repositories;

namespace PCDiagnostics.Core.Domains.Devices.Services;

public class DeviceService : IDeviceService
{
	private readonly IDeviceRepository _deviceRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DeviceService(
		IDeviceRepository deviceRepository,
		IUnitOfWork unitOfWork)
	{
		_deviceRepository = deviceRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task CreateAsync(Device device, CancellationToken cancellationToken)
	{
		await _deviceRepository.CreateAsync(device, cancellationToken);
		await _unitOfWork.SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		await _deviceRepository.DeleteAsync(diagnosticId, name, cancellationToken);
		await _unitOfWork.SaveChangesAsync();
	}

	public Task<bool> ExistsByPK(Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		return _deviceRepository.ExistsByPK(diagnosticId, name, cancellationToken);
	}

	public Task<IEnumerable<Device>> GetAllWithDiagnosticIdAsync(Guid diagnosticId, CancellationToken cancellationToken)
	{
		return _deviceRepository.GetAllWithDiagnosticIdAsync(diagnosticId, cancellationToken);
	}

	public async Task UpdateAsync(Device device, Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		await _deviceRepository.UpdateAsync(device, diagnosticId, name, cancellationToken);
		await _unitOfWork.SaveChangesAsync();
	}
}
