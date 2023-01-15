namespace PCDiagnostics.Core.Domains.Diagnostics.Repositories;

public interface IDiagnosticRepository
{
	Task<Diagnostic> GetByIdAsync(Guid id, CancellationToken cancellationToken);

	Task<IEnumerable<Diagnostic>> GetAllAsync(CancellationToken cancellationToken);

	Task CreateAsync(Diagnostic diagnostic, CancellationToken cancellationToken);

	Task UpdateAsync(Diagnostic diagnostic, CancellationToken cancellationToken);

	Task DeleteAsync(Guid id, CancellationToken cancellationToken);

	Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken);
}
