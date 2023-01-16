using PCDiagnostics.Core.Domains.Diagnostics.Repositories;

namespace PCDiagnostics.Core.Domains.Diagnostics.Services;

public class DiagnosticService : IDiagnosticService
{
	private readonly IDiagnosticRepository _diagnosticRepository;

	public DiagnosticService(IDiagnosticRepository diagnosticRepository)
	{
		_diagnosticRepository = diagnosticRepository;
	}

	public Task CreateAsync(Diagnostic diagnostic, CancellationToken cancellationToken)
	{
		return _diagnosticRepository.CreateAsync(diagnostic, cancellationToken);
	}

	public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		return _diagnosticRepository.DeleteAsync(id, cancellationToken);
	}

	public Task<IEnumerable<Diagnostic>> GetAllAsync(CancellationToken cancellationToken)
	{
		return _diagnosticRepository.GetAllAsync(cancellationToken);
	}

	public Task<Diagnostic> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		return _diagnosticRepository.GetByIdAsync(id, cancellationToken);
	}

	public Task UpdateAsync(Diagnostic diagnostic, Guid id, CancellationToken cancellationToken)
	{
		return _diagnosticRepository.UpdateAsync(diagnostic, id, cancellationToken);
	}
}
