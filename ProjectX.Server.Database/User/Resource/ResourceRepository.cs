using Microsoft.Extensions.Logging;

namespace ProjectX.Server.Database.User.Resource;

public class ResourceRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<ResourceModel>(context, loggerFactory), IResourceRepository
{
    
}