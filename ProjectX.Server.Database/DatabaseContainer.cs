using Microsoft.Extensions.Logging;
using ProjectX.Server.Database.Item;
using ProjectX.Server.Database.ItemInventory;
using ProjectX.Server.Database.SocialIdentity;
using ProjectX.Server.Database.User;
using ProjectX.Server.Database.User.Inventory;
using ProjectX.Server.Database.User.Resource;

namespace ProjectX.Server.Database;

public class DatabaseContainer : IDatabaseContainer
{
    public IUserRepository UserRepository { get; }
    public IResourceRepository ResourceRepository { get; }
    public ISocialIdentityRepository SocialIdentityRepository { get; }
    public IItemRepository ItemRepository { get; }
    public IInventoryRepository InventoryRepository { get; }
    public IItemInventoryRepository ItemInventoryRepository { get; }


    public DatabaseContainer(PostgreSqlContext context, ILoggerFactory loggerFactory)
    {
        UserRepository = new UserRepository(context, loggerFactory);
        ResourceRepository = new ResourceRepository(context, loggerFactory);
        SocialIdentityRepository = new SocialIdentityRepository(context, loggerFactory);
        ItemRepository = new ItemRepository(context, loggerFactory);
        InventoryRepository = new InventoryRepository(context, loggerFactory);
        ItemInventoryRepository = new ItemInventoryRepository(context, loggerFactory);
    }
}