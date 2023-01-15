namespace PCDiagnostics.Core.Domains.Diagnostics.Services;

public interface IDiagnosticService
{
	Task<Diagnostic> GetByIdAsync(Guid id, CancellationToken cancellationToken);

	Task<IEnumerable<Diagnostic>> GetAllAsync(CancellationToken cancellationToken);

	Task CreateAsync(Diagnostic diagnostic, CancellationToken cancellationToken);

	Task UpdateAsync(Diagnostic diagnostic, CancellationToken cancellationToken);

	Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}
