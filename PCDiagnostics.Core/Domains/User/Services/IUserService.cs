namespace PCDiagnostics.Core.Domains.User.Services;

public interface IUserService
{
	Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken);
}
