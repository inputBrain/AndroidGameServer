using Microsoft.Extensions.Logging;

namespace ProjectX.Server.Database.User.Inventory;

public class InventoryRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<InventoryModel>(context, loggerFactory), IInventoryRepository
{
    
}