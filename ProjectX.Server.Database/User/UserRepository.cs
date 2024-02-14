using Microsoft.Extensions.Logging;

namespace ProjectX.Server.Database.User;

public class UserRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<UserModel>(context, loggerFactory), IUserRepository
{
    
}