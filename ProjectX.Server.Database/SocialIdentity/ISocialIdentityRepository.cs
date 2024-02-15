using System;
using System.Threading.Tasks;
using ProjectX.Server.Database.User;
using ProjectX.Server.Model.SocialIdentity;

namespace ProjectX.Server.Database.SocialIdentity;

public interface ISocialIdentityRepository
{
    Task<SocialIdentityModel> Create(
        int userId,
        string uid,
        SocialType socialType,
        DateTime createdAt
    );
    
    Task<(SocialIdentityModel?, UserModel?)> FindByUid(string uid);
}