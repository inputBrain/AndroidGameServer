using Microsoft.Extensions.Logging;

namespace ProjectX.Server.Database.ItemInventory;

public class ItemInventoryRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<ItemInventoryModel>(context, loggerFactory), IItemInventoryRepository
{
    
}