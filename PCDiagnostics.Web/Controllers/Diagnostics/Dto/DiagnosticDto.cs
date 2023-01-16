namespace PCDiagnostics.Web.Controllers.Diagnostics.Dto;

public record DiagnosticDto
{
	public Guid Id { get; init; }
	public DateTime CheckTime { get; init; }
}
