using Microsoft.Extensions.Logging;
using ProjectX.Server.Database.User;
using ProjectX.Server.Database.User.Resource;

namespace ProjectX.Server.Database;

public class DatabaseContainer : IDatabaseContainer
{
    public IUserRepository UserRepository { get; }
    public IResourceRepository ResourceRepository { get; }
    
    
    public DatabaseContainer(PostgreSqlContext context, ILoggerFactory loggerFactory)
    {
        UserRepository = new UserRepository(context, loggerFactory);
        ResourceRepository = new ResourceRepository(context, loggerFactory);
    }
}