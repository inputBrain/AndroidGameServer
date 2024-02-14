using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectX.Server.Database.User;

namespace ProjectX.Server.Database;

public class PostgreSqlContext : DbContext
{
    public IDatabaseContainer Db { get; set; }
    
    public DbSet<UserModel> User { get; set; }


    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        Db = new DatabaseContainer(this, loggerFactory);
    }
}