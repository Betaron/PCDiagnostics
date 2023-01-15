using PCDiagnostics.Core.Domains.Devices;

namespace PCDiagnostics.Data.DbModels.Devices;

public class DeviceDbModel
{
	public Guid DiagnosticId { get; set; }
	public string? Name { get; set; }
	public Dictionary<string, string>? Specs { get; set; }

	public DeviceDbModel(Device coreDevice)
	{
		DiagnosticId = coreDevice.DiagnosticId;
		Name = coreDevice.Name;
		Specs = coreDevice.Specs;
	}
}
