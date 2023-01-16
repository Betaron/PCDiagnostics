namespace PCDiagnostics.Core.Domains.User.Repositories;

public interface IUserRepository
{
	Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken);
}
