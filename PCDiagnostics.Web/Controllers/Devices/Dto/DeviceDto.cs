namespace PCDiagnostics.Web.Controllers.Devices.Dto;

public record DeviceDto
{
	public Guid DiagnosticId { get; init; }
	public string? Name { get; init; }
	public Dictionary<string, string>? Specs { get; init; }
}
