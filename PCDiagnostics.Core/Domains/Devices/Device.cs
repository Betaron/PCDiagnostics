namespace PCDiagnostics.Core.Domains.Devices;

public class Device
{
	public Guid DiagnosticId { get; set; }
	public string? Name { get; set; }
	public Dictionary<string, string>? Specs { get; set; }
}
