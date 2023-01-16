using PCDiagnostics.Core.Domains.Diagnostics.Repositories;

namespace PCDiagnostics.Core.Domains.Diagnostics.Services;

public class DiagnosticService : IDiagnosticService
{
	private readonly IDiagnosticRepository _diagnosticRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DiagnosticService(
		IDiagnosticRepository diagnosticRepository,
		IUnitOfWork unitOfWork)
	{
		_diagnosticRepository = diagnosticRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task CreateAsync(Diagnostic diagnostic, CancellationToken cancellationToken)
	{
		await _diagnosticRepository.CreateAsync(diagnostic, cancellationToken);
		await _unitOfWork.SaveChangesAsync();
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		await _diagnosticRepository.DeleteAsync(id, cancellationToken);
		await _unitOfWork.SaveChangesAsync();
	}

	public Task<IEnumerable<Diagnostic>> GetAllAsync(CancellationToken cancellationToken)
	{
		return _diagnosticRepository.GetAllAsync(cancellationToken);
	}

	public Task<Diagnostic> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		return _diagnosticRepository.GetByIdAsync(id, cancellationToken);
	}

	public async Task UpdateAsync(Diagnostic diagnostic, Guid id, CancellationToken cancellationToken)
	{
		await _diagnosticRepository.UpdateAsync(diagnostic, id, cancellationToken);
		await _unitOfWork.SaveChangesAsync();
	}
}
