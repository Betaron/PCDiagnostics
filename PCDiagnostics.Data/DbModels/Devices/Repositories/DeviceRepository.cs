using Microsoft.EntityFrameworkCore;
using PCDiagnostics.Core.Domains.Devices;
using PCDiagnostics.Core.Domains.Devices.Repositories;
using PCDiagnostics.Core.Exceptions;

namespace PCDiagnostics.Data.DbModels.Devices.Repositories;

public class DeviceRepository : IDeviceRepository
{
	private PCDiagnosticsContext _context;

	public DeviceRepository(PCDiagnosticsContext context)
	{
		_context = context;
	}

	public async Task CreateAsync(Device device, CancellationToken cancellationToken)
	{
		DeviceDbModel deviceDbModel = new(device);
		await _context.AddAsync(deviceDbModel, cancellationToken);
	}

	public async Task DeleteAsync(Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		var entity = await _context.Devices.FirstOrDefaultAsync(it =>
		it.DiagnosticId == diagnosticId &&
		it.Name == name, cancellationToken);

		if (entity is null)
			throw new ObjectNotFoundException(
				message: $"Device - {name} from {diagnosticId} diagnostic not found.");

		_context.Devices.Remove(entity);
	}

	public async Task<bool> ExistsByPK(Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		return await _context.Devices.AnyAsync(it =>
		it.DiagnosticId == diagnosticId &&
		it.Name == name, cancellationToken);
	}

	public async Task<IEnumerable<Device>> GetAllWithDiagnosticIdAsync(Guid diagnosticId, CancellationToken cancellationToken)
	{
		return await (_context.Devices.AsNoTracking()
			.Where(it => it.DiagnosticId == diagnosticId)
			.Select(it => new Device()
			{
				Name = it.Name,
				DiagnosticId = it.DiagnosticId,
				Specs = it.Specs
			})).ToListAsync(cancellationToken);
	}

	public async Task UpdateAsync(Device device, Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		var entity = await _context.Devices.FirstOrDefaultAsync(it =>
		it.DiagnosticId == diagnosticId &&
		it.Name == name, cancellationToken);

		if (entity is null)
			throw new ObjectNotFoundException(
				message: $"Device - {name} from {diagnosticId} diagnostic not found.");

		entity.Name = device.Name;
		entity.DiagnosticId = device.DiagnosticId;
		entity.Specs = device.Specs;
	}
}
