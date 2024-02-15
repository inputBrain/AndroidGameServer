using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectX.Server.Database.User;
using ProjectX.Server.Model.SocialIdentity;

namespace ProjectX.Server.Database.SocialIdentity;

public class SocialIdentityRepository(PostgreSqlContext context, ILoggerFactory loggerFactory) : AbstractRepository<SocialIdentityModel>(context, loggerFactory), ISocialIdentityRepository
{
    public async Task<SocialIdentityModel> Create(int userId, string uid, SocialType socialType, DateTime createdAt)
    {
        var model = SocialIdentityModel.CreateModel(userId, uid, socialType, createdAt);

        var result = await CreateModelAsync(model);
        if (result == null)
        {
            throw new Exception("Firebase user is not created");
        }

        return result;
    }
    
    
    public async Task<(SocialIdentityModel?, UserModel?)> FindByUid(string uid)
    {
        var query = DbModel.Include(x => x.User).ThenInclude(x => x.Resource);
        
        var model = await query.FirstOrDefaultAsync(_ => _.Uid == uid);
        if (model == null)
        {
            return (null, null);
        }

        return (model, model.User);
    }
}