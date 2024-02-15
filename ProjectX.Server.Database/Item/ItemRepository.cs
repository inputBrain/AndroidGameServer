using Microsoft.Extensions.Logging;

namespace ProjectX.Server.Database.Item;

public class ItemRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<ItemModel>(context, loggerFactory), IItemRepository
{
    
}