using Microsoft.AspNetCore.Mvc;
using PCDiagnostics.Core.Domains.Devices;
using PCDiagnostics.Core.Domains.Devices.Services;
using PCDiagnostics.Web.Controllers.Devices.Dto;

namespace PCDiagnostics.Web.Controllers.Devices;

[ApiController]
[Route("device")]
public class DeviceController
{
	private readonly IDeviceService _deviceService;

	public DeviceController(IDeviceService deviceService)
	{
		_deviceService = deviceService;
	}

	[HttpPost]
	public Task Create(DeviceDto model, CancellationToken cancellationToken)
	{
		return _deviceService.CreateAsync(new Device()
		{
			DiagnosticId = model.DiagnosticId,
			Name = model.Name,
			Specs = model.Specs
		}, cancellationToken);
	}

	[HttpDelete("{diagnosticId}/{name}")]
	public Task Delete(Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		return _deviceService.DeleteAsync(diagnosticId, name, cancellationToken);
	}

	[HttpGet("diagnostic-id/{diagnosticId}")]
	public async Task<IEnumerable<DeviceDto>> GetAllDevicesByDiagnosticId(
		Guid diagnosticId, CancellationToken cancellationToken)
	{
		var models = await
			_deviceService.GetAllWithDiagnosticIdAsync(diagnosticId, cancellationToken);

		return models.Select(it => new DeviceDto()
		{
			DiagnosticId = it.DiagnosticId,
			Name = it.Name,
			Specs = it.Specs
		});
	}

	[HttpGet("primary-key/exists/{diagnosticId}/{name}")]
	public Task<bool> ExistsByPK(Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		return _deviceService.ExistsByPK(diagnosticId, name, cancellationToken);
	}

	[HttpPut("{diagnosticId}/{name}")]
	public Task Update(DeviceDto model, Guid diagnosticId, string name, CancellationToken cancellationToken)
	{
		return _deviceService.UpdateAsync(new Device()
		{
			DiagnosticId = model.DiagnosticId,
			Name = model.Name,
			Specs = model.Specs
		}, diagnosticId, name, cancellationToken);
	}
}
