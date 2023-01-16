namespace PCDiagnostics.Core;

public interface IUnitOfWork
{
	Task<int> SaveChangesAsync();
}
