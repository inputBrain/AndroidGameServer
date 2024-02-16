using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ProjectX.Server.Database.User;

public class UserRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<UserModel>(context, loggerFactory), IUserRepository
{
    public async Task<UserModel?> CreateModel(string? firstName, string? lastName, string? phone, string? avatarUrl, DateTime createdAt)
    {
        var model = UserModel.CreateModel(firstName, lastName, phone, avatarUrl, createdAt);
        var result = await CreateModelAsync(model);

        if (result == null)
        {
            Logger.LogCritical("User model is not created");
        }

        return model;
    }
    
    
    public async Task<UserModel?> FindByUid(string uid)
    {
        var model = await DbModel
            .Include(x => x.SocialIdentity)
            .Where(x => x.SocialIdentity.Uid == uid)
            .FirstOrDefaultAsync();
        
        if (model == null)
        {
            Logger.LogWarning("User model is null");
        }
        return model;
    }
}