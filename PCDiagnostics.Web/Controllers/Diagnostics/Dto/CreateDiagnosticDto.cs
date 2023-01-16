namespace PCDiagnostics.Web.Controllers.Diagnostics.Dto;

public record CreateDiagnosticDto
{
	public DateTime CheckTime { get; init; }
}
