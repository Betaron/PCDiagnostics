using PCDiagnostics.Data.DbModels.Devices;

namespace PCDiagnostics.Data.DbModels.Diagnostics;

public class DiagnosticDbModel
{
	public Guid Id { get; set; }
	public DateTime CheckTime { get; set; }
	public List<DeviceDbModel>? Devices { get; set; }
}
