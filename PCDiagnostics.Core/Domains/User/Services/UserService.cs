using PCDiagnostics.Core.Domains.User.Repositories;

namespace PCDiagnostics.Core.Domains.User.Services;

public class UserService : IUserService
{
	private IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken)
	{
		return _userRepository.GetByLoginAsync(login, cancellationToken);
	}
}
