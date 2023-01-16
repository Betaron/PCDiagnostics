using Microsoft.EntityFrameworkCore;
using PCDiagnostics.Core.Domains.User;
using PCDiagnostics.Core.Domains.User.Repositories;
using PCDiagnostics.Core.Exceptions;

namespace PCDiagnostics.Data.DbModels.Users.Repositories;

public class UserRepository : IUserRepository
{
	private readonly PCDiagnosticsContext _context;

	public UserRepository(PCDiagnosticsContext context)
	{
		_context = context;
	}

	public async Task<User> GetByLoginAsync(string login, CancellationToken cancellationToken)
	{
		var entity = await _context.Users.FirstOrDefaultAsync(
			it => it.Login == login, cancellationToken);

		if (entity is null)
			throw new ObjectNotFoundException(
				message: $"User {login} not found");

		return new User()
		{
			Login = entity.Login,
			Key = entity.Key
		};
	}
}
