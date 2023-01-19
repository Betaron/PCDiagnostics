using PCDiagnostics.Core;

namespace PCDiagnostics.Data;

internal class UnitOfWork : IUnitOfWork
{
	private readonly PCDiagnosticsContext _context;

	public UnitOfWork(PCDiagnosticsContext context)
	{
		_context = context;
	}

	public Task<int> SaveChangesAsync()
	{
		return _context.SaveChangesAsync();
	}
}
