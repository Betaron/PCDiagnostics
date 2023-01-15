using PCDiagnostics.Core.Domains.Devices;

namespace PCDiagnostics.Core.Domains.Diagnostics;

public class Diagnostic
{
	public Guid Id { get; set; }
	public DateTime CheckTime { get; set; }
	public List<Device>? Devices { get; set; }
}
