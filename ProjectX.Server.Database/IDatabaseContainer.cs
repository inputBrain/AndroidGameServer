using ProjectX.Server.Database.CountryTileData;
using ProjectX.Server.Database.Item;
using ProjectX.Server.Database.ItemInventory;
using ProjectX.Server.Database.SocialIdentity;
using ProjectX.Server.Database.User;
using ProjectX.Server.Database.User.Inventory;
using ProjectX.Server.Database.User.Resource;

namespace ProjectX.Server.Database;

public interface IDatabaseContainer
{
    IUserRepository UserRepository { get; }
    IResourceRepository ResourceRepository { get; }
    ISocialIdentityRepository SocialIdentityRepository { get; }
    IItemRepository ItemRepository { get; }
    IInventoryRepository InventoryRepository { get; }
    IItemInventoryRepository ItemInventoryRepository { get; }
    
    ICountryTileDataRepository CountryTileDataRepository { get; }

}