using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectX.Server.Database.Item;
using ProjectX.Server.Database.ItemInventory;
using ProjectX.Server.Database.SocialIdentity;
using ProjectX.Server.Database.User;
using ProjectX.Server.Database.User.Inventory;
using ProjectX.Server.Database.User.Resource;

namespace ProjectX.Server.Database;

public class PostgreSqlContext : DbContext
{
    public IDatabaseContainer Db { get; set; }
    
    public DbSet<UserModel> User { get; set; }
    public DbSet<ResourceModel> Resource { get; set; }
    
    public DbSet<SocialIdentityModel> SocialIdentity { get; set; }
    
    public DbSet<InventoryModel> Inventory { get; set; }
    public DbSet<ItemModel> Item { get; set; }
    public DbSet<ItemInventoryModel> ItemInventory { get; set; }


    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        Db = new DatabaseContainer(this, loggerFactory);
    }
}