using Microsoft.EntityFrameworkCore;
using PCDiagnostics.Core.Domains.Diagnostics;
using PCDiagnostics.Core.Domains.Diagnostics.Repositories;
using PCDiagnostics.Core.Exceptions;

namespace PCDiagnostics.Data.DbModels.Diagnostics.Repositories;

public class DiagnosticRepository : IDiagnosticRepository
{
	private PCDiagnosticsContext _context;

	public DiagnosticRepository(PCDiagnosticsContext context)
	{
		_context = context;
	}

	public async Task CreateAsync(Diagnostic diagnostic, CancellationToken cancellationToken)
	{
		DiagnosticDbModel diagnosticDbModel = new(diagnostic);
		await _context.AddAsync(diagnosticDbModel, cancellationToken);
	}

	public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity = await _context.Diagnostics.FirstOrDefaultAsync(
			it => it.Id == id, cancellationToken: cancellationToken);

		if (entity is null)
			throw new ObjectNotFoundException(
				message: $"Diagnostic {id} not found.");

		_context.Diagnostics.Remove(entity);
	}

	public async Task<bool> ExistsByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		return await _context.Diagnostics.AnyAsync(it =>
		it.Id == id, cancellationToken);
	}

	public async Task<IEnumerable<Diagnostic>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await _context.Diagnostics.AsNoTracking()
			.Select(it => new Diagnostic
			{
				Id = it.Id,
				CheckTime = it.CheckTime
			}).ToListAsync(cancellationToken);

	}

	public async Task<Diagnostic> GetByIdAsync(Guid id, CancellationToken cancellationToken)
	{
		var entity =
			await _context.Diagnostics.FirstOrDefaultAsync(it => it.Id == id, cancellationToken);

		if (entity is null)
			throw new ObjectNotFoundException(
				message: $"Diagnostic {id} not found.");

		return new Diagnostic()
		{
			Id = entity.Id,
			CheckTime = entity.CheckTime
		};
	}

	public async Task UpdateAsync(Diagnostic diagnostic, Guid id, CancellationToken cancellationToken)
	{
		var entity = await _context.Diagnostics.FirstOrDefaultAsync(
			it => it.Id == id, cancellationToken);

		if (entity is null)
			throw new ObjectNotFoundException(
				message: $"Diagnostic {id} not found.");

		entity.Id = id;
		entity.CheckTime = diagnostic.CheckTime;
	}
}