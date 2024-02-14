using Microsoft.Extensions.Logging;
using ProjectX.Server.Database.User;

namespace ProjectX.Server.Database;

public class DatabaseContainer : IDatabaseContainer
{
    public IUserRepository UserRepository { get; }
    
    
    public DatabaseContainer(PostgreSqlContext context, ILoggerFactory loggerFactory)
    {
        UserRepository = new UserRepository(context, loggerFactory);
    }
}